using UnityEngine;

namespace Assets._Project.Scripts.World {
    public class LandingPad : MonoBehaviour {

        [SerializeField] private float scoreMultiplier = 1f;

        public float GetScoreMultiplier() {
            return scoreMultiplier;
        }
    }
}
