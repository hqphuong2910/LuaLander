using UnityEngine;

namespace Assets.Scripts {
    public class GameLevel : MonoBehaviour {
        [SerializeField] private int levelNumber = 1;
        [SerializeField] private Transform landerStartPosTransform;

        public int GetLevelNumber() {
            return levelNumber;
        }

        public Vector3 GetLanderStartPos() {
            return landerStartPosTransform.position;
        }
    }
}
