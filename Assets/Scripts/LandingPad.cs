using UnityEngine;

namespace Assets.Scripts
{
        public class LandingPad : MonoBehaviour {

            [SerializeField] private float scoreMultiplier = 1f;

            public float GetScoreMultiplier() {
                return scoreMultiplier;
            }
        }
}
