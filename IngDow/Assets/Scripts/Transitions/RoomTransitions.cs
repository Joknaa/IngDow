using System.Collections;
using Camera;
using UnityEngine;
using UnityEngine.UI;

namespace Transitions {
    public class RoomTransitions: MonoBehaviour {
        public CameraController CameraScript;

        [Header("Camera & Position Variables: ")]
        public float CameraTranslation;
        public Vector3 PlayerTranslation;


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                CameraScript.MoveCamera(CameraTranslation);
                other.transform.position += PlayerTranslation;
            }
        }
    }
}