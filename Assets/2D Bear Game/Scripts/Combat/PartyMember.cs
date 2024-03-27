using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat
{
    public interface IControllable
    {
        Transform ObjectTransform { get; }
        void Posess(PlayerCombatController controller);
        void UnPosess();
        void Move(Vector2 moveInput);
    }

    public class PartyMember : MonoBehaviour, IControllable
    {

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;

        private PlayerCombatController controller;
        private Vector2 moveDirection;

        public Transform ObjectTransform => transform;

        public void Move(Vector2 moveInput)
        {
            moveDirection = moveInput;
        }

        public void Posess(PlayerCombatController controller)
        {
            this.controller = controller;
        }

        public void UnPosess()
        {
            controller = null;
        }

        private void FixedUpdate()
        {
            if (controller == null) return;
            rb.velocity = moveDirection.normalized * speed;
        }

    }
}
