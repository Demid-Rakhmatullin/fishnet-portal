using UnityEngine;

namespace Assets.Game.Scripts.Managers
{
    class ConnectionUIManager : MonoSingleton<ConnectionUIManager>
    {
        [SerializeField] GameObject connectingText;

        public void ShowConnectionText()
            => connectingText.SetActive(true);

        public void HideConnectionText()
            => connectingText.SetActive(false);
    }
}
