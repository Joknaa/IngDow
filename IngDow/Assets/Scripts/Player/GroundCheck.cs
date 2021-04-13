using UnityEngine;

public class GroundCheck : MonoBehaviour {
    private GameObject Player;

    private void Start() {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            Player.GetComponent<CharacterController2D>().IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            Player.GetComponent<CharacterController2D>().IsGrounded = false;
        }
    }
}
