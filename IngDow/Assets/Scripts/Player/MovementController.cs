using System;
using UnityEngine;

namespace Player {
    public class MovementController : MonoBehaviour {
        [SerializeField] private float Speed;
        [SerializeField] private float JumpForce = 400f;
        [Header("Collision Detection")] [SerializeField]
        private float GroundCollisionRange;
        [SerializeField] private LayerMask GroundLayer;

        private SpriteRenderer playerSpriteRenderer;
        private Rigidbody2D playerRigidbody2D;
        private BoxCollider2D playerCollider;
        private float moveDirection = 0;
        public  bool IsJumping;
        public bool IsGrounded = true;

        private void Start() {
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<BoxCollider2D>();
        }

        private void Update() {
            moveDirection = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space)) {
                IsJumping = true;
            }
        }

        private void FixedUpdate() {
            IsGrounded = HasDetectedGround();
            Vector2 moveVelocity = new Vector2(Speed * Time.deltaTime * moveDirection, playerRigidbody2D.velocity.y);
            playerRigidbody2D.velocity = moveVelocity;

            if (IsJumping && IsGrounded) {
                Vector2 jumpVelocity = new Vector2(0f, JumpForce);
                playerRigidbody2D.AddForce(jumpVelocity, ForceMode2D.Force);
                IsJumping = false;
            }
    
            playerSpriteRenderer.flipX = moveDirection < 0;
        }
        
        private bool HasDetectedGround() {
            Bounds SquareBounds = playerCollider.bounds;
            float Distance = SquareBounds.extents.y + GroundCollisionRange;

            RaycastHit2D GroundRaycast = Physics2D.Raycast(SquareBounds.center, Vector2.down, Distance, GroundLayer);
            Debug.DrawRay(SquareBounds.center, Vector2.down * Distance);
            return GroundRaycast;
        }

        public float get_MoveDirection => moveDirection;
        public bool get_IsGrounded => IsGrounded;
        public bool get_IsJumping => IsJumping;
    }
}