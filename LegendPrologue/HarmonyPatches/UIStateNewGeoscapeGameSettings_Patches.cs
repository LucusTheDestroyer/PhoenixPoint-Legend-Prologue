using HarmonyLib;
using PhoenixPoint.Home.View.ViewStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace LegendPrologue.Harmony 
{
    [HarmonyPatch(typeof(UIStateNewGeoscapeGameSettings), "GameSettings_OnConfirm", new Type[]{})]
    public static class LegendByDefault_Patch2
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> listInstructions = new List<CodeInstruction>(instructions);
            IEnumerable<CodeInstruction> insert = new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Stloc_S, 6),
            };

            for (int i=0; i < instructions.Count(); i++)
            {
                if(listInstructions[i].opcode == OpCodes.Stloc_S && listInstructions[i].operand is LocalBuilder local && local.LocalIndex == 6)
                {
                    listInstructions.InsertRange(i+1, insert);
                    return listInstructions;
                }
            }
            return instructions;
        }
    }
}