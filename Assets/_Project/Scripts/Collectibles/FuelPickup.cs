using Assets._Project.Scripts.Core;

namespace Assets._Project.Scripts.Collectibles {
    public class FuelPickup : CustomMonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
