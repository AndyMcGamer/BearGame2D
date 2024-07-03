using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BearGame.Game.Input
{
    public class PlayerInputProcessor : InputProcessor
    {
        public static PlayerInputProcessor instance;

        public Vector2 MoveInput { get; private set; }
        public event Action<Vector2> OnMoveInputChanged;

        protected override void Awake()
        {
            base.Awake();

            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.started) return;
            MoveInput = context.ReadValue<Vector2>();
            //print($"{context.phase} {MoveInput}");
            OnMoveInputChanged?.Invoke(MoveInput);
        }
    }
}
