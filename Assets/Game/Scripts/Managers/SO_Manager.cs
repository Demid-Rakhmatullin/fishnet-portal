using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    class SO_Manager : MonoSingleton<SO_Manager>
    {
        [SerializeField] GameConfig _gameConfig;

        public GameConfig GameConfig => _gameConfig;
    }
}
