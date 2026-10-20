using UnityEngine;

namespace Assets.Scripts {
    public class SoundManager : MonoBehaviour {
        [SerializeField] private AudioClip coinPickupAudioClip;
        [SerializeField] private AudioClip fuelPickupAudioClip;
        [SerializeField] private AudioClip landingSuccessAudioClip;
        [SerializeField] private AudioClip crashAudioClip;

        private void Start() {
            Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
            Lander.Instance.OnFuelPickup += Lander_OnFuelPickup;
            Lander.Instance.OnLanded += Lander_OnLanded;
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e) {
            switch (e.landingType) {
                default:
                    AudioSource.PlayClipAtPoint(crashAudioClip, Camera.main.transform.position);
                    break;
                case Lander.LandingType.Success:
                    AudioSource.PlayClipAtPoint(landingSuccessAudioClip, Camera.main.transform.position);
                    break;
            }
        }

        private void Lander_OnFuelPickup(object sender, System.EventArgs e) {
            AudioSource.PlayClipAtPoint(fuelPickupAudioClip, Camera.main.transform.position);
        }

        private void Lander_OnCoinPickup(object sender, System.EventArgs e) {
            AudioSource.PlayClipAtPoint(coinPickupAudioClip, Camera.main.transform.position);
        }
    }
}
