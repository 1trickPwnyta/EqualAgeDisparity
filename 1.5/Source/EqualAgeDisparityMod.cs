using HarmonyLib;
using Verse;

namespace EqualAgeDisparity
{
    public class EqualAgeDisparityMod : Mod
    {
        public const string PACKAGE_ID = "equalagedisparity.1trickPwnyta";
        public const string PACKAGE_NAME = "Equal Age Disparity";

        public EqualAgeDisparityMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
