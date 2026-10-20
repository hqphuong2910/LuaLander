using UnityEngine;

namespace Assets.Scripts {
    public class LanderAudio : MonoBehaviour {
        [SerializeField] private AudioSource thrusterAudioSource;

        private Lander lander;

        private void Start() {
            lander = GetComponent<Lander>();

            lander.OnNoForce += Lander_OnNoForce;
            lander.OnUpForce += Lander_OnUpForce;
            lander.OnRightForce += Lander_OnRightForce;
            lander.OnLeftForce += Lander_OnLeftForce;

            SoundManager.Instance.OnSoundVolumeChanged += SoundManager_OnSoundVolumeChanged;

            thrusterAudioSource.volume = SoundManager.Instance.GetSoundVolumeNormalized();
            thrusterAudioSource.Pause();
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
