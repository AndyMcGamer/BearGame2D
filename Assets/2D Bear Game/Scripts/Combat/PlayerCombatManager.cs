using BearGame.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BearGame.Combat
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerCombatManager : MonoBehaviour
    {
        [SerializeField] private List<BearController> party;
        private int currentControllerIndex;
        private BearController ActivePartyMember => party[currentControllerIndex];

        [Header("Input Settings")]
        [SerializeField] private PlayerInput playerInput;

        private readonly string actionMapPlayerControls = "Combat";
        private readonly string actionMapMenuControls = "UI";

        private string currentControlScheme;


        private void Awake()
        {
            currentControlScheme = playerInput.currentControlScheme;
            currentControllerIndex = 0;
            ActivePartyMember.FocusMember();
        }

        public void ActivateControls()
        {
            playerInput.ActivateInput();
        }

        public void DeactivateControls()
        {
            playerInput.DeactivateInput();
        }

        public void OnControlsChanged()
        {
            if(playerInput.currentControlScheme != currentControlScheme)
            {
                currentControlScheme = playerInput.currentControlScheme;
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 inputMovement = context.ReadValue<Vector2>();
            ActivePartyMember.OnMovement(inputMovement);
        }

        public void OnSwap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ActivePartyMember.UnfocusMember();
                currentControllerIndex = MathHelper.Mod(currentControllerIndex + (int)context.ReadValue<float>(), party.Count);
                ActivePartyMember.FocusMember();
            }
        }

        public void EnableMovementControls()
        {
            playerInput.SwitchCurrentActionMap(actionMapPlayerControls);
        }

        public void EnableUIControls()
        {
            playerInput.SwitchCurrentActionMap(actionMapMenuControls);
        }
    }
}
