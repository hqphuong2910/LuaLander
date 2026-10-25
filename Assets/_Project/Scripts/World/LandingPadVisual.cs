using Assets._Project.Scripts.Core;
using TMPro;
using UnityEngine;

namespace Assets._Project.Scripts.World {
    [RequireComponent(typeof(LandingPad))]
    public class LandingPadVisual : CustomMonoBehaviour {
        [SerializeField] private TextMeshPro scoreMultiplierTextMesh;

        protected override void LoadSelf() {
            base.LoadSelf();

            LandingPad landingPad = GetComponent<LandingPad>();
            scoreMultiplierTextMesh.text = "x" + landingPad.GetScoreMultiplier();
        }
    }
}
