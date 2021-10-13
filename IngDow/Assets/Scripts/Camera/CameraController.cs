using System;
using UnityEngine;

namespace Camera {
    public class CameraController : MonoBehaviour {
        private Transform playerTransform;
        private float cameraPosition;
        
        private void Start() {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void MoveCamera(float translation) {
            Vector2 CurrentPosition = transform.position;
            transform.position = new Vector3(CurrentPosition.x + translation, CurrentPosition.y, -10);
        }

        private void LateUpdate() {
            Vector3 currentPosition = transform.position;
            transform.position = new Vector3(playerTransform.position.x, currentPosition.y, currentPosition.z);
        }
    }
}