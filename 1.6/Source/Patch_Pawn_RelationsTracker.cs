using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EqualAgeDisparity
{
    [HarmonyPatch(typeof(Pawn_RelationsTracker))]
    [HarmonyPatch(nameof(Pawn_RelationsTracker.LovinAgeFactor))]
    public static class Patch_Pawn_RelationsTracker
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            int num10s = 0;
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    switch ((float)instruction.operand)
                    {
                        case 30f: instruction.operand = 20f; break;
                        case 10f:
                            num10s++;
                            if (num10s == 1 || num10s == 4) instruction.operand = 7f;
                            if (num10s == 2 || num10s == 3) instruction.operand = 20f;
                            break;
                        case 3f: instruction.operand = 7f; break;
                    }
                }

                yield return instruction;
            }
        }
    }
}
