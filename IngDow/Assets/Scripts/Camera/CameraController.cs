using UnityEngine;

namespace Camera {
    public class CameraController : MonoBehaviour {

        public void MoveCamera(float translation) {
            transform.position = new Vector3(transform.position.x + translation, transform.position.y, -10);
        }
    }
}