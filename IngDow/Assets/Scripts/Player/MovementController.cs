using System;
using UnityEngine;

namespace Player {
    public class MovementController : MonoBehaviour {
        [SerializeField] private float Speed = 0;
        [SerializeField] private float JumpForce = 400f;
        [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
        [SerializeField] private bool AirControl = false;

        private Rigidbody2D playerRigidbody2D;
        private SpriteRenderer playerSpriteRenderer;
        public float moveDirection = 0;
        public bool IsJumping;
        public bool IsGrounded = true;
        private Rigidbody2D Rigid;
        private Vector3 Velocity = Vector3.zero;

        private void Start() {
            Rigid = GetComponent<Rigidbody2D>();
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update() {
            moveDirection = Input.GetAxisRaw("Horizontal");
            IsJumping = Input.GetKey(KeyCode.Space);
        }

        private void FixedUpdate() {
            playerRigidbody2D.velocity =
                new Vector2(Speed * Time.deltaTime * moveDirection, playerRigidbody2D.velocity.y);
            playerSpriteRenderer.flipX = moveDirection < 0;
            Move(moveDirection, IsJumping);
        }

        private void Move(float move, bool jump) {
            if (IsGrounded || AirControl) {
                Vector3 targetVelocity = new Vector2(move * 10f, Rigid.velocity.y);
                Rigid.velocity = Vector3.SmoothDamp(Rigid.velocity, targetVelocity, ref Velocity, MovementSmoothing);
            }

            if (IsGrounded && jump) {
                IsGrounded = false;
                Rigid.AddForce(new Vector2(0f, JumpForce));
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                IsGrounded = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                IsGrounded = false;
            }
        }
    }
}