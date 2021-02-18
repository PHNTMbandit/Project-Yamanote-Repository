using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectYamanote.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool ActionInput { get; private set; }
        public bool PhoneInput { get; private set; }

        public Player player;

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }

        public void OnActionInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ActionInput = true;
            }
        }

        public void OnPhoneInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PhoneInput = true;
            }
        }

        public void UseActionInput() => ActionInput = false;
        public void UsePhoneInput() => PhoneInput = false;
    }
}
