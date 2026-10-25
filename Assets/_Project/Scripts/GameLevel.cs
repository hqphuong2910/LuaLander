using Assets._Project.Scripts.Core;
using UnityEngine;

namespace Assets._Project.Scripts {
    public class GameLevel : CustomMonoBehaviour {
        [SerializeField] private int levelNumber = 1;
        [SerializeField] private Transform landerStartPosTransform;
        [SerializeField] private Transform cameraStartTargetTransform;
        [SerializeField] private float zoomedOutOrthographicSize;

        public int GetLevelNumber() {
            return levelNumber;
        }

        public Vector3 GetLanderStartPos() {
            return landerStartPosTransform.position;
        }

        public Transform GetCameraStartTargetTransform() {
            return cameraStartTargetTransform;
        }

        public float GetZoomedOutOrthographicSize() {
            return zoomedOutOrthographicSize;
        }
    }
}
