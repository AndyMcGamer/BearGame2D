using BearGame.Game.Input;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Player.Overworld
{
    public class OverworldMovement : OverworldPlayerComponent
    {
        [SerializeField] private float moveSpeed;
        [SerializeField, ReadOnly] private Vector2 lastMoveDir;

        public override void Init(PlayerManager playerManager)
        {
            base.Init(playerManager);            
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            PlayerInputProcessor.instance.OnMoveInputChanged += OnMoveInputChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            PlayerInputProcessor.instance.OnMoveInputChanged -= OnMoveInputChanged;
        }

        private void OnMoveInputChanged(Vector2 input)
        {
            if (input.sqrMagnitude > 0)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else if (Mathf.Abs(input.x) < Mathf.Abs(input.y))
                {
                    input.x = 0;
                }
                else
                {
                    if (Mathf.Abs(lastMoveDir.x) > 0)
                    {
                        input.x = 0;
                    }
                    else
                    {
                        input.y = 0;
                    }
                }
            }

            lastMoveDir = input.normalized;
            playerManager.rb.velocity = lastMoveDir * moveSpeed;
        }
    }
}
