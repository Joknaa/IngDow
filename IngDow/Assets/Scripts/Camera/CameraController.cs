using System;
using Unity.Mathematics;
using UnityEngine;

namespace Camera {
    public class CameraController : MonoBehaviour {
        [SerializeField] private float transitionSmoothing = 0.1f;
        private float cameraPosition = 15;
        private float cameraNewPosition = 15;

        private void LateUpdate() {
            cameraPosition = Mathf.Lerp(cameraPosition, cameraNewPosition, transitionSmoothing);
            MoveCamera();
        }

        public void SetCameraPosition(float CameraTranslation) {
            cameraNewPosition = cameraPosition + CameraTranslation;
        }

        private void MoveCamera() {
            Vector3 currentPosition = transform.position;
            transform.position = new Vector3(cameraPosition, currentPosition.y, currentPosition.z);
        }
    }
}