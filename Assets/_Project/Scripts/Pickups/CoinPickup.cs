using UnityEngine;

namespace Assets._Project.Scripts.Pickups {
    public class CoinPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
