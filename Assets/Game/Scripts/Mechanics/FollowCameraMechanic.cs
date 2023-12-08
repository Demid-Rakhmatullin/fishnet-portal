using Cinemachine;
using UnityEngine;

namespace Assets.Game.Scripts.Mechanics
{
    class FollowCameraMechanic
    {
        private readonly CinemachineVirtualCamera _camera;
        private readonly string _targetObjectTag;

        public FollowCameraMechanic(CinemachineVirtualCamera camera, string targetObjectTag)
        {
            _camera = camera;
            _targetObjectTag = targetObjectTag;
        }

        public bool SearchTarget()
        {
            if (!_camera.Follow)
            {
                var target = GameObject.FindGameObjectWithTag(_targetObjectTag);
                if (target)
                {
                    _camera.Follow = target.transform;
                    return true;
                }
            }

            return false;
        }
    }
}
