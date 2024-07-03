using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BearGame.Player
{
    public abstract class PlayerManager : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("List of all player components"), SerializeField, ReorderableList] private PlayerComponent[] _playerComponents;

        /// <summary>
        /// Actual Player Component List
        /// </summary>
        private readonly Dictionary<string, PlayerComponent> playerComponents = new();

        protected virtual void Awake()
        {
            foreach (var playerComponent in _playerComponents.OrderBy(x => x.Order))
            {

                string componentName = playerComponent.Name;
                if (!playerComponents.ContainsKey(componentName))
                {
                    playerComponents.Add(componentName, playerComponent);
                }
                else
                {
                    Debug.LogWarning($"Duplicate PlayerComponent name: {componentName}. Skipping initialization.");
                    continue;
                }

                playerComponent.Init(this);
            }
        }

        public T GetPlayerComponent<T>() where T : PlayerComponent
        {
            playerComponents.TryGetValue(typeof(T).Name, out var component);
            return component as T;
        }

#if UNITY_EDITOR
        [Button]
        private void RebuildPlayerComponents()
        {
            _playerComponents = GetComponentsInChildren<PlayerComponent>();

        }
#endif
    }
}
