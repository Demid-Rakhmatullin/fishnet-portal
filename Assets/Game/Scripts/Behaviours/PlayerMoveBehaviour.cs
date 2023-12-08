using Assets.Game.Scripts.Managers;
using Assets.Game.Scripts.Mechanics;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    class PlayerMoveBehaviour : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;
        [SerializeField] Animator modelAnimator;
        [SerializeField] float speed;
        [SerializeField] float rotationSpeed = 10f;

        private SimpleMoveMechanic _moveMeh;
        private MoveAnimationMechanic _animationMeh;

        void Awake()
        {
            _moveMeh = new SimpleMoveMechanic(characterController);
            _animationMeh = new MoveAnimationMechanic(modelAnimator);
        }

        void Update()
        {
            var moveDir = InputManager.Instance.GetMoveInput();

            if (moveDir.sqrMagnitude > 0f)
            {
                _animationMeh.StartRun();
                _moveMeh.Move(moveDir, speed, rotationSpeed);
            }
            else
            {
                _animationMeh.StopRun();
            }
        }
    }
}
