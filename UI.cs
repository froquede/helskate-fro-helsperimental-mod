using MelonLoader;
using RapidGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HelsperimentalMod
{
    public class UI : MelonMod
    {
        private Rect windowRect = new Rect(Screen.width - 492, 12, 480, 360);
        public bool showMainMenu = false;
        private Vector2 scrollPosition = Vector2.zero;
        GUIStyle boxpadded = new GUIStyle("Box");
        int loadLevel = 0;

        void DrawWindow(int windowID)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            GUILayout.BeginVertical(boxpadded);
            {
                GroundTuning gt = GameManager.SkaterController.GroundTuning;
                gt.MaxGroundNormalAngle = RGUI.SliderFloat(gt.MaxGroundNormalAngle, 0, 360f, 50f, "Max angle between up and ground normal to be counted as ground");
                gt.Drag = RGUI.SliderFloat(gt.Drag, 0, 10f, 1.85f, "Drag while skating");
                gt.DragJumpHeld = RGUI.SliderFloat(gt.DragJumpHeld, 0, 10f, 1.50f, "Drag while skating and holding jump");
                gt.GroundAcceleration = RGUI.SliderFloat(gt.GroundAcceleration, 0, 10000f, 7500f, "Ground force added per second");

                GUILayout.Space(12);
                gt.GroundBrakeDrag = RGUI.SliderFloat(gt.GroundBrakeDrag, 0, 10f, 5f, "Drag while braking/entering runout");
                gt.GroundBrakeFactor = RGUI.SliderFloat(gt.GroundBrakeFactor, 0, 1f, .1f, "Factor to reduce velocity while braking/entering runout");

                GUILayout.Space(12);
                gt.TurnValueMinGround = RGUI.SliderFloat(gt.TurnValueMinGround, 0, 100f, 75f, "Min speed for steering while grounded");
                gt.TurnAccelerateGround = RGUI.SliderFloat(gt.TurnAccelerateGround, 0, 1000f, 150f, "Rate to increase the speed for steering while grounded");
                gt.TurnDecelerateGround = RGUI.SliderFloat(gt.TurnDecelerateGround, 0, 1000f, 720f, "Rate to decrease the speed for steering while grounded");
                gt.TurnMaxGround = RGUI.SliderFloat(gt.TurnMaxGround, 0, 1000f, 150f, "Max speed for steering while grounded");

                GUILayout.Space(12);
                gt.ManualTurnValueMinGround = RGUI.SliderFloat(gt.ManualTurnValueMinGround, 0, 1000f, 120f, "Min speed for steering while manualing");
                gt.ManualTurnAccelerateGround = RGUI.SliderFloat(gt.ManualTurnAccelerateGround, 0, 10000f, 200f, "Rate to increase the speed for steering while manualing");
                gt.ManualTurnDecelerateGround = RGUI.SliderFloat(gt.ManualTurnDecelerateGround, 0, 10000f, 720f, "Rate to decrease the speed for steering while manualing");
                gt.ManualTurnMaxGround = RGUI.SliderFloat(gt.ManualTurnMaxGround, 0, 10000f, 250f, "Max speed for steering while manualing");

                GUILayout.Space(12);
                gt.LockedOnTurnValueMinGround = RGUI.SliderFloat(gt.LockedOnTurnValueMinGround, 0, 10000f, 125f, "Min speed for steering while locked on");
                gt.LockedOnTurnMaxGround = RGUI.SliderFloat(gt.LockedOnTurnMaxGround, 0, 10000f, 220f, "Max speed for steering while locked on");

                GUILayout.Space(12);
                gt.HoverHeight = RGUI.SliderFloat(gt.HoverHeight, 0, 10000f, .01f, "How high to hover above ground");
                gt.LeanMaxAngle = RGUI.SliderFloat(gt.LeanMaxAngle, 0, 10000f, 337.5f, "Angular velocity where the lean is equal to 1");

                GUILayout.Space(12);
                gt.JumpForce = RGUI.SliderFloat(gt.JumpForce, 0, 200f, 80f, "Amount of force to be applied when jumping");
                gt.SideJumpForce = RGUI.SliderFloat(gt.SideJumpForce, 0, 200f, 35f, "Amount of force to be applied sideways when jumping");
                gt.MaxNumberOfJumps = (int)RGUI.SliderFloat(gt.MaxNumberOfJumps, 0, 10f, 1f, "Number of jumps available");
                gt.JumpCooldown = RGUI.SliderFloat(gt.JumpCooldown, 0, 1f, .25f, "Cooldown between jumps");
                gt.GraceTimeJump = RGUI.SliderFloat(gt.GraceTimeJump, 0, 1f, .3f, "Amount of time to allow jumping after entering air state");

                GUILayout.Space(12);
                gt.GroundingRayLength = RGUI.SliderFloat(gt.GroundingRayLength, 0, 3f, 1.5f, "Length of the ray detecting ground");
                gt.WallRayLength = RGUI.SliderFloat(gt.WallRayLength, 0, 3f, .75f, "Length of the ray detecting wall bounces");
                gt.WallBounceCatchUpDuration = RGUI.SliderFloat(gt.WallBounceCatchUpDuration, 0, 3f, .1f, "Length of the ray detecting wall bounces");

                GUILayout.Space(12);
                loadLevel = (int)RGUI.SliderFloat(loadLevel, 0, 7f, 0, "Load level: ");
                if(GUILayout.Button("Load Level"))
                {
                    SceneManager.LoadSceneAsync(loadLevel + 4, LoadSceneMode.Single);
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }

        public override void OnGUI()
        {
            if (showMainMenu && GameManager.SkaterController != null)
            {
                GUI.backgroundColor = new Color(0f, 0f, 0f, 0.85f);
                boxpadded.padding = new RectOffset(12, 12, 12, 12);
                windowRect = GUILayout.Window(0, windowRect, DrawWindow, "Fro's Helsperimental Mod");
            }
        }

        public bool originalCursor = false;
        public float lastTimeScale = 1f;
        public override void OnUpdate()
        {
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.F))
            {
                if (showMainMenu)
                {
                    Close();
                }
                else
                {
                    Open();
                }
            }

            if (showMainMenu)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        private void Open()
        {
            lastTimeScale = Time.timeScale;
            originalCursor = Cursor.visible;
            showMainMenu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        private void Close()
        {
            showMainMenu = false;
            Cursor.visible = originalCursor;
            Time.timeScale = lastTimeScale;
        }
    }
}
