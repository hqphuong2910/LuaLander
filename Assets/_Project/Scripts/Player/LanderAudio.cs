using Assets._Project.Scripts.Core;
using Assets._Project.Scripts.Managers;
using UnityEngine;

namespace Assets._Project.Scripts.Player {
    [RequireComponent(typeof(Lander))]
    public class LanderAudio : CustomMonoBehaviour {
        [SerializeField] private AudioSource thrusterAudioSource;

        private Lander lander;

        protected override void LoadSelf() {
            base.LoadSelf();

            lander = GetComponent<Lander>();

            thrusterAudioSource.Pause();
        }

        protected override void LoadDependencies() {
            base.LoadDependencies();

            thrusterAudioSource.volume = SoundManager.Instance.GetSoundVolumeNormalized();
        }

        protected override void SubscribeEvents() {
            base.SubscribeEvents();

            lander.OnNoForce += Lander_OnNoForce;
            lander.OnUpForce += Lander_OnUpForce;
            lander.OnRightForce += Lander_OnRightForce;
            lander.OnLeftForce += Lander_OnLeftForce;
            SoundManager.Instance.OnSoundVolumeChanged += SoundManager_OnSoundVolumeChanged;
        }

        protected override void UnsubscribeEvents() {
            base.UnsubscribeEvents();

            lander.OnNoForce -= Lander_OnNoForce;
            lander.OnUpForce -= Lander_OnUpForce;
            lander.OnRightForce -= Lander_OnRightForce;
            lander.OnLeftForce -= Lander_OnLeftForce;
            SoundManager.Instance.OnSoundVolumeChanged -= SoundManager_OnSoundVolumeChanged;
        }

        private void SoundManager_OnSoundVolumeChanged(object sender, System.EventArgs e) {
            thrusterAudioSource.volume = SoundManager.Instance.GetSoundVolumeNormalized();
        }

        private void Lander_OnLeftForce(object sender, System.EventArgs e) {
            if (!thrusterAudioSource.isPlaying) {
                thrusterAudioSource.Play();
            }
        }

        private void Lander_OnRightForce(object sender, System.EventArgs e) {
            if (!thrusterAudioSource.isPlaying) {
                thrusterAudioSource.Play();
            }
        }

        private void Lander_OnUpForce(object sender, System.EventArgs e) {
            if (!thrusterAudioSource.isPlaying) {
                thrusterAudioSource.Play();
            }
        }

        private void Lander_OnNoForce(object sender, System.EventArgs e) {
            thrusterAudioSource.Pause();
        }
    }
}
