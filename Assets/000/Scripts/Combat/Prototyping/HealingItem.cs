using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat.Prototype
{
    public class HealingItem : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsEnemy;
        public void Activate()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 0.2f, whatIsEnemy);
            foreach (Collider2D enemy in enemies)
            {
                SimpleEnemy enemyScript = enemy.gameObject.GetComponent<SimpleEnemy>();
                enemyScript.Convert();
            }
            Destroy(gameObject);
        }
    }
}
