using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat.Prototype
{
    public class SimpleEnemy : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer sprite;

        private bool converted = false;
        private void Awake()
        {
            sprite.color = Color.red;
            converted = false;
        }

        private void FixedUpdate()
        {
            if (converted) return;
            Vector2 moveDir = target.position - transform.position;
            rb.velocity = moveDir.normalized * moveSpeed;
        }

        public void Convert()
        {
            sprite.color = Color.green;
        }

    }
}
