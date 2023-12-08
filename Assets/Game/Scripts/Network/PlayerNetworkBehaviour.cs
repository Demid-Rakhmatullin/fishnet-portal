using Assets.Game.Scripts.Behaviours;
using FishNet.Object;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Network
{
    class PlayerNetworkBehaviour : NetworkBehaviour
    {
        public static event Action<Transform> OnSpawned;

        [SerializeField] PlayerMoveBehaviour moveBehaviour;

        private void Awake()
        {
            moveBehaviour.enabled = false;
        }
         

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (IsOwner)
            {
                moveBehaviour.enabled = true;
                OnSpawned?.Invoke(transform);
            }
        }
    }
}
