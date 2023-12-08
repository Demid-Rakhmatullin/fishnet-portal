using Assets.Game.Scripts.Managers;
using FishNet;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.Behaviours
{
    class SceneIntializationBehaviour : MonoBehaviour
    {
        void Awake()
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case Scenes.Singleplayer:
                    if (ServerBuild)
                    {
                        SceneChangeManager.Instance.LoadScene(Scenes.Multiplayer);
                    }
                    break;
                case Scenes.Multiplayer:
                    ConnectionUIManager.Instance.ShowConnectionText();
                    if (ServerBuild)
                    {
                        InstanceFinder.ServerManager.StartConnection();
                        InstanceFinder.ServerManager.OnServerConnectionState += ServerManager_OnServerConnectionState;
                    }
                    else
                    {
                        InstanceFinder.ClientManager.StartConnection();
                        InstanceFinder.ClientManager.OnClientConnectionState += ClientManager_OnClientConnectionState;
                    }
                    break;
            }
        }

        private bool ServerBuild
            => SO_Manager.Instance.GameConfig.ServerBuild;

        private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
        {
            if (obj.ConnectionState == LocalConnectionState.Started)
                ConnectionUIManager.Instance.HideConnectionText();
        }

        private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
        {
            if (obj.ConnectionState == LocalConnectionState.Started)
                ConnectionUIManager.Instance.HideConnectionText();
        }
    }
}
