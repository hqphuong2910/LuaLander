using Assets._Project.Scripts.Core;
using Assets._Project.Scripts.Managers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class PauseUI : CustomMonoBehaviour {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button soundVolumeButton;
        [SerializeField] private TextMeshProUGUI soundVolumeTextMesh;
        [SerializeField] private Button musicVolumeButton;
        [SerializeField] private TextMeshProUGUI musicVolumeTextMesh;

        protected override void Start() {
            base.Start();

            Hide();
        }

        protected override void LoadDependencies() {
            base.LoadDependencies();

            AddListeners();

            soundVolumeTextMesh.text = "SOUND: " + SoundManager.Instance.GetSoundVolumePercentage() + "%";
            musicVolumeTextMesh.text = "MUSIC: " + MusicManager.Instance.GetMusicVolumePercentage() + "%";
        }

        protected override void SubscribeEvents() {
            base.SubscribeEvents();

            GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
            GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        }

        protected override void UnsubscribeEvents() {
            base.UnsubscribeEvents();

            GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
            GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
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

        private void AddListeners() {
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
    }
}
