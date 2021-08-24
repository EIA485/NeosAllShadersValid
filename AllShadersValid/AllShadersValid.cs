using HarmonyLib;
using NeosModLoader;
using System.Threading.Tasks;
using CloudX.Shared;
namespace AllShadersValid
{
    public class AllShadersValid : NeosMod
    {
        public override string Name => "AllShadersValid";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.AllShadersValid");
            harmony.PatchAll();

        }
        [HarmonyPatch(typeof(CloudXInterface), "IsValidShader")]
        class AllShadersValidPatch
        {
             public static bool Prefix(ref Task<bool> __result) {
                __result = Task<bool>.Run(() => {
                    return true;
                });
                return false;
            }
        }
    }
}
