
namespace Assets.Game.Scripts
{
    class Singleton<T>
        where T : new()
    {
        private static readonly T instance = new();

        public static T Instance => instance;
    }
}
