using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }

        [SerializeField] private CinemachineCamera cinemachineCamera;

        private static int levelNumber = 1;
        [SerializeField] private List<GameLevel> gameLevelList;

        private bool isTimerActive;
        private int score;
        private float time;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
            Lander.Instance.OnLanded += Lander_OnLanded;
            Lander.Instance.OnStateChanged += Lander_OnStateChanged;

            LoadCurrentLevel();
        }

        private void Update() {
            if (isTimerActive) {
                time += Time.deltaTime;
            }
        }

        private void LoadCurrentLevel() {
            foreach (GameLevel gameLevel in gameLevelList) {
                if (gameLevel.GetLevelNumber() == levelNumber) {
                    GameLevel spawnedLevel = Instantiate(gameLevel, Vector3.zero, Quaternion.identity);
                    Lander.Instance.transform.position = spawnedLevel.GetLanderStartPos();
                    cinemachineCamera.Target.TrackingTarget = spawnedLevel.GetCameraStartTargetTransform();
                    CinemachineCameraZoom2D.Instance.SetTargetOrthographicSize(spawnedLevel.GetZoomedOutOrthographicSize());
                }
            }
        }

        private void Lander_OnStateChanged(object sender, Lander.OnStateChangedEventArgs e) {
            if (e.newState == Lander.State.Normal) {
                isTimerActive = true;
                cinemachineCamera.Target.TrackingTarget = Lander.Instance.transform;
                CinemachineCameraZoom2D.Instance.SetNormalOrthographicSize();
            }
        }

        private void Lander_OnCoinPickup(object sender, EventArgs e) {
            AddScore(500);
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e) {
            AddScore(e.score);
        }

        private void AddScore(int scoreAmount) {
            score += scoreAmount;
        }

        public int GetScore() {
            return score;
        }

        public float GetTime() {
            return time;
        }

        public int GetLevelNumber() {
            return levelNumber;
        }

        public void GoToNextLevel() {
            levelNumber++;
            SceneManager.LoadScene(0);
        }

        public void RetryLevel() {
            SceneManager.LoadScene(0);
        }
    }
}
