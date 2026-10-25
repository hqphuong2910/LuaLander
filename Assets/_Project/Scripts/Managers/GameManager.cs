using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace Assets._Project.Scripts.Managers {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }

        public event EventHandler OnGamePaused;
        public event EventHandler OnGameUnpaused;

        [SerializeField] private CinemachineCamera cinemachineCamera;

        [SerializeField] private List<GameLevel> gameLevelList;

        private static int levelNumber = 1;
        private static int totalScore = 0;

        private bool isTimerActive;
        private float time;

        private int score;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
            Lander.Instance.OnLanded += Lander_OnLanded;
            Lander.Instance.OnStateChanged += Lander_OnStateChanged;

            GameInput.Instance.OnMenuButtonPressed += GameInput_OnMenuButtonPressed;

            LoadCurrentLevel();
        }

        private void Update() {
            if (isTimerActive) {
                time += Time.deltaTime;
            }
        }

        private GameLevel GetGameLevel() {
            foreach (GameLevel gameLevel in gameLevelList) {
                if (gameLevel.GetLevelNumber() == levelNumber) {
                    return gameLevel;
                }
            }
            return null;
        }

        private void LoadCurrentLevel() {
            GameLevel gameLevel = GetGameLevel();
            GameLevel spawnedLevel = Instantiate(gameLevel, Vector3.zero, Quaternion.identity);
            Lander.Instance.transform.position = spawnedLevel.GetLanderStartPos();
            cinemachineCamera.Target.TrackingTarget = spawnedLevel.GetCameraStartTargetTransform();
            CinemachineCameraZoom2D.Instance.SetTargetOrthographicSize(spawnedLevel.GetZoomedOutOrthographicSize());
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

        private void GameInput_OnMenuButtonPressed(object sender, EventArgs e) {
            PauseUnpauseGame();
        }

        private void AddScore(int scoreAmount) {
            score += scoreAmount;
        }

        public int GetScore() {
            return score;
        }

        public int GetTotalScore() {
            return totalScore;
        }

        public float GetTime() {
            return time;
        }

        public int GetLevelNumber() {
            return levelNumber;
        }

        public void GoToNextLevel() {
            levelNumber++;
            totalScore += score;

            if (GetGameLevel() == null) {
                SceneLoader.LoadScene(SceneLoader.Scene.GameOverScene);
            } else {
                SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
            }
        }

        public void RetryLevel() {
            SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
        }

        public void PauseUnpauseGame() {
            if (Time.timeScale == 1f) {
                PauseGame();
            } else {
                UnpauseGame();
            }
        }

        public void PauseGame() {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }

        public void UnpauseGame() {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }

        public static void ResetStaticData() {
            totalScore = 0;
            levelNumber = 1;
        }
    }
}
