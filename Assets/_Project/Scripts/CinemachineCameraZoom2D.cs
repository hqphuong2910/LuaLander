using Assets._Project.Scripts.Core;
using Unity.Cinemachine;
using UnityEngine;

namespace Assets._Project.Scripts {
    public class CinemachineCameraZoom2D : CustomMonoBehaviour {
        public static CinemachineCameraZoom2D Instance { get; private set; }

        private const float NORMAL_ORTHOGRAPHIC_SIZE = 10f;
        private float targetOrthographicSize;

        [SerializeField] private CinemachineCamera cinemachineCamera;

        protected override void LoadSelf() {
            base.LoadSelf();

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
