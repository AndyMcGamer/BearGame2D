using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Combat
{
    public class CombatCamera : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}
