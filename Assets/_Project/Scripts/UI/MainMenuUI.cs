using Assets._Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class MainMenuUI : MonoBehaviour {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Awake() {
            Time.timeScale = 1f;

            playButton.onClick.AddListener(() => {
                GameManager.ResetStaticData();
                SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
            });
            quitButton.onClick.AddListener(() => {
                Application.Quit();
            });
        }

        private void Start() {
            playButton.Select();
        }
    }
}
