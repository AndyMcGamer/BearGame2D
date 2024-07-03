using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Player
{
    public abstract class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField, ReadOnly] public string Name { get; private set; }
        [field: SerializeField, Tooltip("Order for initialization. Negative values will be initialized first")] public virtual int Order { get; private set; }

        protected PlayerManager playerManager;
        protected bool initialized = false;

        protected virtual void Awake()
        {
            initialized = false;
        }

        protected virtual void OnEnable()
        {
            if (!initialized) return;
        }

        protected virtual void OnDisable()
        {
            if(!initialized) return;
        }

        public virtual void Init(PlayerManager playerManager)
        {
            this.playerManager = playerManager;
            initialized = true;
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Name = this.GetType().Name;
        }
#endif
    }
}
