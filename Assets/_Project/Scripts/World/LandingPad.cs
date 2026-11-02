using Assets._Project.Scripts.Core;
using UnityEngine;

namespace Assets._Project.Scripts.World {
    public class LandingPad : CustomMonoBehaviour {

        [SerializeField] private float scoreMultiplier = 1f;

        public float GetScoreMultiplier() {
            return scoreMultiplier;
        }
    }
}
