using UnityEngine.SceneManagement;

namespace Assets._Project.Scripts {
    public static class SceneLoader {
        public enum Scene {
            MainMenuScene,
            GameScene,
            GameOverScene,
        }

        public static void LoadScene(Scene scene) {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
