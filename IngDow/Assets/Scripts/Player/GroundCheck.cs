using System;
using UnityEngine;

namespace Player {
    public class GroundCheck : MonoBehaviour {
        private GameObject Player;

        private void Start() {
            Player = gameObject.transform.parent.gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                Player.GetComponent<CharacterController2D>().IsGrounded = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                Player.GetComponent<CharacterController2D>().IsGrounded = false;
            }
        }
    }
}
