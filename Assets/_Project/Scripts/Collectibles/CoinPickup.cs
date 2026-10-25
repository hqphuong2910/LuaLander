using Assets._Project.Scripts.Core;

namespace Assets._Project.Scripts.Collectibles {
    public class CoinPickup : CustomMonoBehaviour {
        public void DestroySelf() {
            Destroy(gameObject);
        }
    }
}
