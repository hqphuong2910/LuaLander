using UnityEngine;

namespace Assets._Project.Scripts.Collectibles {
    public class FuelPickup : MonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
