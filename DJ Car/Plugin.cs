using Harmony;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using System.Reflection;

namespace DJ_Car
{
    public class Plugin : IPlugin, IUpdatable
    {
        public static CarLogic Car => G.Sys.PlayerManager_?.Current_?.playerData_?.Car_?.GetComponent<CarLogic>() ?? G.Sys.PlayerManager_?.Current_?.playerData_?.CarLogic_ ?? null;
        public static CarStats CarStats => Car?.CarStats_ ?? null;

        public void Initialize(IManager manager, string ipcIdentifier)
        {
            HarmonyInstance harmony = HarmonyInstance.Create("com.reherc.djcar");
            harmony.PatchAll(Assembly.GetCallingAssembly());
        }

        public void Update()
        {
            try
            {
                AudioManager.SetRTPCValue("Replay_Music_Playback_Speed", CarStats ? CarStats.GetSpeed() : 1.0f, null);
            }
            catch (System.Exception) { }
        }
    }
}