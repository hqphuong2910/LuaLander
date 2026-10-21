using Assets._Project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class GameOverUI : MonoBehaviour {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private TextMeshProUGUI scoreTextMesh;

        private void Awake() {
            mainMenuButton.onClick.AddListener(() => {
                SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
            });
        }

        private void Start() {
            mainMenuButton.Select();

            scoreTextMesh.text = "FINAL SCORE: " + GameManager.Instance.GetTotalScore();
        }
    }
}
