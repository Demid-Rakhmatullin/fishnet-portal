using Assets.Game.Scripts.Behaviours;
using UnityEngine;

namespace Assets.Game.Scripts.Network
{
    class PlayerCameraNetworkBehaviour : MonoBehaviour
    {
        [SerializeField] PlayerMainCameraBehaviour playerCameraBehaviour;

        void Awake()
        {
            PlayerNetworkBehaviour.OnSpawned += PlayerNetworkBehaviour_OnSpawned;
        }

        private void OnDestroy()
        {
            PlayerNetworkBehaviour.OnSpawned -= PlayerNetworkBehaviour_OnSpawned;
        }

        private void PlayerNetworkBehaviour_OnSpawned(Transform obj)
            => playerCameraBehaviour.SearchTarget();
    }
}
