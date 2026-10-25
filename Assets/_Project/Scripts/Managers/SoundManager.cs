using Assets._Project.Scripts.Player;
using System;
using UnityEngine;

namespace Assets._Project.Scripts.Managers {
    public class SoundManager : MonoBehaviour {
        public static SoundManager Instance { get; private set; }

        public event EventHandler OnSoundVolumeChanged;

        private const int SOUND_MAX_VOLUME_PERCENTAGE = 100;
        private static int soundVolumePercentage = 50;

        [SerializeField] private AudioClip coinPickupAudioClip;
        [SerializeField] private AudioClip fuelPickupAudioClip;
        [SerializeField] private AudioClip landingSuccessAudioClip;
        [SerializeField] private AudioClip crashAudioClip;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
            Lander.Instance.OnFuelPickup += Lander_OnFuelPickup;
            Lander.Instance.OnLanded += Lander_OnLanded;
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e) {
            switch (e.landingType) {
                default:
                    AudioSource.PlayClipAtPoint(crashAudioClip, Camera.main.transform.position, GetSoundVolumeNormalized());
                    break;
                case Lander.LandingType.Success:
                    AudioSource.PlayClipAtPoint(landingSuccessAudioClip, Camera.main.transform.position, GetSoundVolumeNormalized());
                    break;
            }
        }

        private void Lander_OnFuelPickup(object sender, System.EventArgs e) {
            AudioSource.PlayClipAtPoint(fuelPickupAudioClip, Camera.main.transform.position, GetSoundVolumeNormalized());
        }

        private void Lander_OnCoinPickup(object sender, System.EventArgs e) {
            AudioSource.PlayClipAtPoint(coinPickupAudioClip, Camera.main.transform.position, GetSoundVolumeNormalized());
        }

        public void ChangeSoundVolume() {
            int increasingPercentage = 10;
            soundVolumePercentage += increasingPercentage;
            if (soundVolumePercentage > SOUND_MAX_VOLUME_PERCENTAGE) { soundVolumePercentage = 0; }
            OnSoundVolumeChanged?.Invoke(this, EventArgs.Empty);
        }

        public int GetSoundVolumePercentage() {
            return soundVolumePercentage;
        }

        public float GetSoundVolumeNormalized() {
            return (float)soundVolumePercentage / SOUND_MAX_VOLUME_PERCENTAGE;
        }
    }
}
