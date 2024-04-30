using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat
{
    public interface IPlayerState
    {
        BearController Controller { get; }
        void Enter();
        void Execute();
        void Exit();
    }

    public class PlayerIdleState : IPlayerState
    {
        private BearController _controller;
        public BearController Controller => _controller;

        public PlayerIdleState(BearController bearController)
        {
            _controller = bearController;
        }

        public void Enter()
        {

        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }

    public class PlayerMoveState : IPlayerState
    {
        private BearController _controller;
        public BearController Controller => _controller;

        public PlayerMoveState(BearController bearController)
        {
            _controller = bearController;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
            _controller.MovePlayer();
        }

        public void Exit()
        {
            _controller.rb.velocity = Vector2.zero;
        }
    }
}
