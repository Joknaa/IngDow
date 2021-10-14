using System;
using System.Collections;
using Camera;
using UnityEngine;
using UnityEngine.UI;

namespace Transitions {
    public class RoomTransitions: MonoBehaviour {
        private CameraController CameraScript;

        [Header("Camera & Position Variables: ")]
        public float CameraTranslation;
        public Vector3 PlayerTranslation;

        private void Start() {
            CameraScript = UnityEngine.Camera.main.GetComponent<CameraController>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                CameraScript.SetCameraPosition(CameraTranslation);
                other.transform.position += PlayerTranslation;
            }
        }
    }
}