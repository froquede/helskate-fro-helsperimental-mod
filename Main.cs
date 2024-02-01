using MelonLoader;

namespace HelsperimentalMod
{
    public static class BuildInfo
    {
        public const string Name = "FrosHelsperimentalMod"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Experimental mod"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Fro"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class FrosHelsperimentalMod : MelonMod
    {
        public UI ui;
        public override void OnInitializeMelon() {
            MelonLogger.Msg("OnApplicationStart");
        }

        public override void OnLateInitializeMelon() // Runs after OnApplicationStart.
        {
            MelonLogger.Msg("OnApplicationLateStart");
            ui = new UI();
            MelonLogger.Msg("UI created");
        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
        }

        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName) {
            MelonLogger.Msg("OnSceneWasUnloaded: " + buildIndex.ToString() + " | " + sceneName);
        }

        public override void OnUpdate() // Runs once per frame.
        {
            //MelonLogger.Msg("OnUpdate");
            ui.OnUpdate();
        }

        public override void OnGUI()
        {
            ui.OnGUI();
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            //MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            //MelonLogger.Msg("OnLateUpdate");
        }

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
            MelonLogger.Msg("OnApplicationQuit");
        }

        public override void OnPreferencesSaved() // Runs when Melon Preferences get saved.
        {
            MelonLogger.Msg("OnPreferencesSaved");
        }

        public override void OnPreferencesLoaded() // Runs when Melon Preferences get loaded.
        {
            MelonLogger.Msg("OnPreferencesLoaded");
        }
    }
}