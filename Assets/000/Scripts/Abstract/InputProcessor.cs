using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BearGame.Game.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public abstract class InputProcessor : MonoBehaviour
    {
        [SerializeField, ReadOnly] private PlayerInput playerInput;

        private string currentControlScheme;
        private string chosenActionMap;

        protected virtual void Awake()
        {
            if(playerInput == null) playerInput = GetComponent<PlayerInput>();
            currentControlScheme = playerInput.currentControlScheme;
            chosenActionMap = playerInput.currentActionMap.name;

            playerInput.SwitchCurrentActionMap(chosenActionMap);
        }

        public void OnControlsChanged()
        {
            if (playerInput.currentControlScheme != currentControlScheme)
            {
                currentControlScheme = playerInput.currentControlScheme;
            }
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            playerInput = GetComponent<PlayerInput>();
        }
#endif
    }
}
