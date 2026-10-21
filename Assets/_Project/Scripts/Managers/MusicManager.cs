using System;
using UnityEngine;

namespace Assets._Project.Scripts.Managers {
    public class MusicManager : MonoBehaviour {
        public static MusicManager Instance { get; private set; }

        public event EventHandler OnMusicVolumeChanged;

        private const int MUSIC_MAX_VOLUME_PERCENTAGE = 100;
        private static int musicVolumePercentage = 20;
        private AudioSource musicAudioSource;
        private static float musicTime;

        private void Awake() {
            Instance = this;

            musicAudioSource = GetComponent<AudioSource>();
            musicAudioSource.volume = GetMusicVolumeNormalized();
            musicAudioSource.time = musicTime;
        }

        private void Update() {
            musicTime = musicAudioSource.time;
        }

        public void ChangeMusicVolume() {
            int increasingPercentage = 10;
            musicVolumePercentage += increasingPercentage;
            if (musicVolumePercentage > MUSIC_MAX_VOLUME_PERCENTAGE) { musicVolumePercentage = 0; }
            musicAudioSource.volume = GetMusicVolumeNormalized();
            OnMusicVolumeChanged?.Invoke(this, EventArgs.Empty);
        }

        public int GetMusicVolumePercentage() {
            return musicVolumePercentage;
        }

        public float GetMusicVolumeNormalized() {
            return (float)musicVolumePercentage / MUSIC_MAX_VOLUME_PERCENTAGE;
        }
    }
}
