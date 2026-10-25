using Assets._Project.Scripts.Core;
using Assets._Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class MainMenuUI : CustomMonoBehaviour {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        protected override void Start() {
            base.Start();

            playButton.Select();
        }

        protected override void LoadSelf() {
            base.LoadSelf();

            Time.timeScale = 1f;

            playButton.onClick.AddListener(() => {
                GameManager.ResetStaticData();
                SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
            });

            quitButton.onClick.AddListener(() => {
                Application.Quit();
            });
        }
    }
}
