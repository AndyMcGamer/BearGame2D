using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat.Prototype
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;
        private HealingItem currentItem;
        public void SpawnItem()
        {
            if(currentItem != null)
            {
                Destroy(currentItem.gameObject);
            }
            currentItem = Instantiate(itemPrefab, transform.position, Quaternion.identity).GetComponent<HealingItem>();
        }

        public void ActivateItem()
        {
            if(currentItem != null) currentItem.Activate();
        }
    }
}
