using TMPro;
using UnityEngine;

namespace Assets._Project.Scripts.World {
    [RequireComponent(typeof(LandingPad))]
    public class LandingPadVisual : MonoBehaviour {
        [SerializeField] private TextMeshPro scoreMultiplierTextMesh;

        private void Awake() {
            LandingPad landingPad = GetComponent<LandingPad>();
            scoreMultiplierTextMesh.text = "x" + landingPad.GetScoreMultiplier();
        }
    }
}
