using UnityEngine;

namespace Assets.Scripts.Pickups {
    public class CoinPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
