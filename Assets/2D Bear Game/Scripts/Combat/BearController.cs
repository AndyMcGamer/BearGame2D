using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace BearGame.Combat
{
    public class BearController : MonoBehaviour
    {
        [Header("State Machine")]
        private PlayerStateMachine playerStateMachine;

        [Header("References")]
        public Rigidbody2D rb;
        [SerializeField] private CinemachineVirtualCamera cam;

        [Header("Movement")]
        [SerializeField] private float moveAcceleration;
        [SerializeField] private float maxSpeed;
        private Vector2 rawMoveInput;

        private void Awake()
        {
            playerStateMachine = new();
            playerStateMachine.SetState(new PlayerMoveState(this));
        }

        public void FocusMember()
        {
            cam.Priority = 1;
        }

        public void UnfocusMember()
        {
            cam.Priority = 0;
        }

        public void OnMovement(Vector2 moveInput)
        {
            rawMoveInput = moveInput;
        }

        public void MovePlayer()
        {
            rb.AddForce(moveAcceleration * rawMoveInput);
            if(rb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }

        private void Update()
        {
            playerStateMachine.Execute();
        }
    }
}
