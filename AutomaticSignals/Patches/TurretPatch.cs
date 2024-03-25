using AutomaticSignals.Checkers;
using GameNetcodeStuff;
using HarmonyLib;

namespace AutomaticSignals.Patches;

[HarmonyPatch(typeof(Turret))]
public static class TurretPatch {
    [HarmonyPatch("CheckForPlayersInLineOfSight")]
    [HarmonyPostfix]
    public static void AfterCheckForPlayersInLineOfSight(Turret __instance, ref PlayerControllerB __result) {
        if (!Transmitter.IsSignalTranslatorUnlocked())
            return;

        TurretChecker.CheckTurrets(__instance, ref __result);
    }
}