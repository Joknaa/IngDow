using UnityEngine;

namespace Player {
    public class MovementController : MonoBehaviour {
        public CharacterController2D Controller;
        public float Speed = 4f;
        public float xAxis;
        public bool Jump = false;
    
        private void Update() {
            xAxis = Input.GetAxisRaw("Horizontal") * Speed;
            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump = true;
            }
        }

        private void FixedUpdate() {
            Controller.Move(xAxis * Time.fixedDeltaTime, Jump);
            Jump = false;
        }
    }
}