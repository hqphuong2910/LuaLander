using Unity.Cinemachine;
using UnityEngine;

namespace Assets.Scripts {
    public class CinemachineCameraZoom2D : MonoBehaviour {

        public static CinemachineCameraZoom2D Instance { get; private set; }
        [SerializeField] private CinemachineCamera cinemachineCamera;
        private const float NORMAL_ORTHOGRAPHIC_SIZE = 10f;
        private float targetOrthographicSize;

        private void Awake() {
            Instance = this;
            SetNormalOrthographicSize();
        }

        private void Update() {
            float zoomSpeed = 2f;
            cinemachineCamera.Lens.OrthographicSize = Mathf.Lerp(cinemachineCamera.Lens.OrthographicSize,
                targetOrthographicSize,
                Time.deltaTime * zoomSpeed
            );
        }

        public void SetTargetOrthographicSize(float orthographicSize) {
            targetOrthographicSize = orthographicSize;
        }

        public float SetNormalOrthographicSize() {
            return targetOrthographicSize = NORMAL_ORTHOGRAPHIC_SIZE;
        }
    }
}
