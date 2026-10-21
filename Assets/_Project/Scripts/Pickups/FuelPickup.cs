using UnityEngine;

namespace Assets._Project.Scripts.Pickups {
    public class FuelPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
