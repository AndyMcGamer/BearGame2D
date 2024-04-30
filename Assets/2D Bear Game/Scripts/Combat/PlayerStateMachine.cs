using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat
{
    public class PlayerStateMachine
    {
        private IPlayerState currentState;

        public void SetState(IPlayerState state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }

        public void Execute()
        {
            currentState?.Execute();
        }
    }
}
