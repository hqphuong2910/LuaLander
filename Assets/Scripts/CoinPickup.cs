using UnityEngine;

namespace Assets.Scripts
{
    public class CoinPickup : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
