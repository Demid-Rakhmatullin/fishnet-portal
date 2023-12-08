using UnityEngine;

namespace Assets.Game.Scripts.Mechanics
{
    class SimpleMoveMechanic
    {
        private readonly CharacterController _characterController;

        public SimpleMoveMechanic(CharacterController characterController)
        {
            _characterController = characterController;
        }

        public void Move(Vector3 moveDirection, float moveSpeed, float rotationSpeed)
        {
            var lookDirection = Vector3.RotateTowards(_characterController.transform.forward,
                moveDirection, rotationSpeed * Time.deltaTime, 0f);

            _characterController.transform.rotation = Quaternion.LookRotation(lookDirection);

            _characterController.SimpleMove(moveSpeed * moveDirection);
        }
    }
}
