using HarmonyLib;
using PhoenixPoint.Home.View.ViewControllers;
using PhoenixPoint.Home.View.ViewModules;
using System;
using System.Linq;

namespace LegendPrologue.Harmony
{ 
    [HarmonyPatch(typeof(UIModuleGameSettings), "MainOptions_OnElementSelected", new Type[]{typeof(GameOptionViewController)})]
    public static class LegendByDefault_Patch
    {
        public static void Postfix(UIModuleGameSettings __instance, GameOptionViewController option)
        {
            GameOptionViewController TutorialBox = __instance.SecondaryOptions.Elements.First<GameOptionViewController>();
            TutorialBox.gameObject.SetActive(true);
        }
    }
}