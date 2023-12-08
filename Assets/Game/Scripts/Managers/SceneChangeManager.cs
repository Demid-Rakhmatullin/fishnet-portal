using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.Managers
{
    class SceneChangeManager : Singleton<SceneChangeManager>
    {
        public void LoadScene(string name)
            => SceneManager.LoadScene(name);
    }
}
