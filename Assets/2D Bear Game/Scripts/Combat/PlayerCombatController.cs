using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat
{
    public class PlayerCombatController : MonoBehaviour
    {
        [SerializeField] private Transform pawnContainer;
        [SerializeField] private CombatCamera cam;
        
        private List<IControllable> party;

        private int currentPawnIndex;

        private IControllable CurrentPawn => party[currentPawnIndex];

        private void Awake()
        {
            party = new();
            foreach (Transform child in pawnContainer)
            {
                var controllable = child.GetComponent<IControllable>();
                party.Add(controllable);
            }
            currentPawnIndex = 0;
            CurrentPawn.Posess(this);
            cam.target = CurrentPawn.ObjectTransform;
        }

        private void Update()
        {
            Vector2 moveInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            CurrentPawn.Move(moveInput);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentPawn.UnPosess();
                currentPawnIndex = (currentPawnIndex + 1) % party.Count;
                CurrentPawn.Posess(this);
                cam.target = CurrentPawn.ObjectTransform;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentPawn.UnPosess();
                currentPawnIndex = 0;
                CurrentPawn.Posess(this);
                cam.target = CurrentPawn.ObjectTransform;
            }else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentPawn.UnPosess();
                currentPawnIndex = 1 % party.Count;
                CurrentPawn.Posess(this);
                cam.target = CurrentPawn.ObjectTransform;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentPawn.UnPosess();
                currentPawnIndex = 2 % party.Count;
                CurrentPawn.Posess(this);
                cam.target = CurrentPawn.ObjectTransform;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CurrentPawn.UnPosess();
                currentPawnIndex = 3 % party.Count;
                CurrentPawn.Posess(this);
                cam.target = CurrentPawn.ObjectTransform;
            }
        }
    }
}
