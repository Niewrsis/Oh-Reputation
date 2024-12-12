using UnityEngine.SceneManagement;

namespace SceneSystem
{
    public static class SwitchScene
    {
        public static void SwitchSceneTo(int sceneIndex) { SceneManager.LoadScene(sceneIndex); }

        public static void RestartScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
}