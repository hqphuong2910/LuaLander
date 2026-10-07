using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private int score;
        private float time;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
            Lander.Instance.OnLanded += Lander_OnLanded;
        }

        private void Update()
        {
            time += Time.deltaTime;
        }

        private void Lander_OnCoinPickup(object sender, EventArgs e)
        {
            AddScore(500);
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
        {
            AddScore(e.score);
        }

        private void AddScore(int scoreAmount)
        {
            score += scoreAmount;
        }

        public int GetScore()
        {
            return score;
        }

        public float GetTime()
        {
            return time;
        }
    }
}
