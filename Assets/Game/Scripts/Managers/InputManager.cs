using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    class InputManager : Singleton<InputManager>
    {
        public Vector3 GetMoveInput()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
    }
}
