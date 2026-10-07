using UnityEngine;

namespace Assets.Welcome {
    [CreateAssetMenu(fileName = "Welcome2DScript", menuName = "Welcome/Welcome2DScript")]
    class Welcome2DScript : ScriptableObject {
        public static void Open2DLandingPage() {
            Application.OpenURL("https://unity.com/features/2d");
        }
    }
}
