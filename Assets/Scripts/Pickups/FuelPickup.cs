using UnityEngine;

namespace Assets.Scripts.Pickups {
    public class FuelPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
