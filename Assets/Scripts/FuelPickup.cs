using UnityEngine;

namespace Assets.Scripts {
    public class FuelPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
