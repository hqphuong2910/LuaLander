using Assets._Project.Scripts.Core;
using Assets._Project.Settings.Input;
using System;

namespace Assets._Project.Scripts {
    public class GameInput : CustomMonoBehaviour {
        public static GameInput Instance { get; private set; }

        public event EventHandler OnMenuButtonPressed;

        private InputActions inputActions;

        protected override void LoadSelf() {
            base.LoadSelf();

            Instance = this;

            inputActions = new();
            inputActions.Enable();
        }

        protected override void SubscribeEvents() {
            base.SubscribeEvents();

            inputActions.Player.Menu.performed += Menu_performed;
        }

        protected override void UnsubscribeEvents() {
            base.UnsubscribeEvents();

            inputActions.Player.Menu.performed -= Menu_performed;
        }

        private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
            OnMenuButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnDestroy() {
            inputActions.Disable();
        }

        public bool IsUpActionPressed() {
            return inputActions.Player.LanderUp.IsPressed();
        }

        public bool IsRightActionPressed() {
            return inputActions.Player.LanderRight.IsPressed();
        }

        public bool IsLeftActionPressed() {
            return inputActions.Player.LanderLeft.IsPressed();
        }
    }
}
