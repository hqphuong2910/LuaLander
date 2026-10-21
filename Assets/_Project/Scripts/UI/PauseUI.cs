using Assets._Project.Scripts.Managers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class PauseUI : MonoBehaviour {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button soundVolumeButton;
        [SerializeField] private TextMeshProUGUI soundVolumeTextMesh;
        [SerializeField] private Button musicVolumeButton;
        [SerializeField] private TextMeshProUGUI musicVolumeTextMesh;

        private void Awake() {
            resumeButton.onClick.AddListener(() => {
                GameManager.Instance.UnpauseGame();
            });
            mainMenuButton.onClick.AddListener(() => {
                SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
            });
            soundVolumeButton.onClick.AddListener(() => {
                SoundManager.Instance.ChangeSoundVolume();
                soundVolumeTextMesh.text = "SOUND: " + SoundManager.Instance.GetSoundVolumePercentage() + "%";
            });
            musicVolumeButton.onClick.AddListener(() => {
                MusicManager.Instance.ChangeMusicVolume();
                musicVolumeTextMesh.text = "MUSIC: " + MusicManager.Instance.GetMusicVolumePercentage() + "%";
            });
        }

        private void Start() {
            GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
            GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

            soundVolumeTextMesh.text = "SOUND: " + SoundManager.Instance.GetSoundVolumePercentage() + "%";
            musicVolumeTextMesh.text = "MUSIC: " + MusicManager.Instance.GetMusicVolumePercentage() + "%";

            Hide();
        }

        private void GameManager_OnGamePaused(object sender, EventArgs e) {
            Show();
        }

        private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
            Hide();
        }

        private void Show() {
            resumeButton.Select();

            gameObject.SetActive(true);
        }

        private void Hide() {
            gameObject.SetActive(false);
        }
    }
}
