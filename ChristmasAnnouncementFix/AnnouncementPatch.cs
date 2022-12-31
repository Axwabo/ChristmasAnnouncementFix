using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Respawning.NamingRules;

namespace ChristmasAnnouncementFix {

    [HarmonyPatch(typeof(NineTailedFoxNamingRule), nameof(NineTailedFoxNamingRule.PlayEntranceAnnouncement))]
    internal static class AnnouncementPatch {

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) =>
            instructions.Select(i => i.operand is "XMAS_HASENTERED " ? new CodeInstruction(i.opcode, " XMAS_HASENTERED ") : i);

    }

}
