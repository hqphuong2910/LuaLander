using UnityEngine;

namespace Assets._Project.Scripts.Collectibles {
    public class CoinPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
