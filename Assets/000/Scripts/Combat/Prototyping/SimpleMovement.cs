using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat.Prototype
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;

        private Vector2 moveInput;
        private void Update()
        {
            moveInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }


        private void FixedUpdate()
        {
            rb.velocity = moveInput.normalized * speed;
        }
    }
}
