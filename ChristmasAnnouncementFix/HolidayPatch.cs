using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

namespace ChristmasAnnouncementFix {

    [HarmonyPatch(typeof(ClutterSpawner), nameof(ClutterSpawner.IsHolidayActive))]
    internal static class HolidayPatch {

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator) {
            var list = new List<CodeInstruction>(instructions);
            var label = generator.DefineLabel();
            list[0].labels.Add(label);
            list.InsertRange(0, new CodeInstruction[] {
                new(OpCodes.Call, AccessTools.PropertyGetter(typeof(CafPlugin), nameof(CafPlugin.EnforceChristmas))),
                new(OpCodes.Brfalse_S, label),
                new(OpCodes.Ldarg_0),
                new(OpCodes.Ldc_I4, (int) Holidays.Christmas),
                new(OpCodes.Ceq),
                new(OpCodes.Ret)
            });
            return list;
        }

    }

}
