using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat.Prototype
{
    public class ActionMenu : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform player;

        [SerializeField] private RectTransform actionMenu;
        [SerializeField] private Vector2 offset;
        [SerializeField] private float slowedTimeScale;

        private bool showingActionMenu;
        private void Awake()
        {
            showingActionMenu = false;
            actionMenu.gameObject.SetActive(false);
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                ToggleActionMenu();
            }
        }

        public void ToggleActionMenu()
        {
            showingActionMenu = !showingActionMenu;
            actionMenu.gameObject.SetActive(showingActionMenu);
            actionMenu.anchoredPosition = cam.WorldToScreenPoint(player.position) / actionMenu.transform.parent.transform.localScale.x; 
            Time.timeScale = showingActionMenu ? slowedTimeScale : 1f;
        }
    }
}
