using Assets.Game.Scripts.Managers;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
    class MultiplayerPortalBehaviour : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ScreenFadeManager.Instance.StartFadeIn(() =>
                {
                    SceneChangeManager.Instance.LoadScene(Scenes.Multiplayer);
                });
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                ScreenFadeManager.Instance.CancelFadeIn();
            }
        }
    }
}
