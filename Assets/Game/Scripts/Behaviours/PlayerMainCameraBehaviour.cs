using Assets.Game.Scripts.Mechanics;
using Cinemachine;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    class PlayerMainCameraBehaviour : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera CCVirtualCamera;

        private FollowCameraMechanic _cameraMech;

        void Awake()
        {
            _cameraMech = new FollowCameraMechanic(CCVirtualCamera, Tags.Player);
        }

        void Start()
        {
            SearchTarget();
        }

        public bool SearchTarget()
            => _cameraMech.SearchTarget();
    }
}
