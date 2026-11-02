using Assets._Project.Scripts.Core;
using Assets._Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class GameOverUI : CustomMonoBehaviour {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private TextMeshProUGUI scoreTextMesh;

        protected override void Start() {
            base.Start();

            mainMenuButton.Select();
        }

        protected override void LoadSelf() {
            base.LoadSelf();

            mainMenuButton.onClick.AddListener(() => {
                SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
            });
        }

        protected override void LoadDependencies() {
            base.LoadDependencies();

            scoreTextMesh.text = "FINAL SCORE: " + GameManager.Instance.GetTotalScore();
        }
    }
}
