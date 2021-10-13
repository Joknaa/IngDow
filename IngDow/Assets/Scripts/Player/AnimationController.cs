using System;
using UnityEngine;

namespace Player {
    public enum PlayerState {
        Idle,
        Jump,
        Walk,
        Run
    }
    public class AnimationController : MonoBehaviour {
        [SerializeField] private Sprite playerJumpSprite;
        private SpriteRenderer PlayerSprite;
        private Animator PlayerAnimator;
        private PlayerState CurrentState;
        private MovementController MovementController;

        private void Start() {
            PlayerSprite = GetComponent<SpriteRenderer>();
            PlayerAnimator = GetComponent<Animator>();
            MovementController = GetComponent<MovementController>();
            //CharacterController2D = GetComponent<CharacterController2D>();
        }

        public void ChangeAnimationState(PlayerState newState) {
            if (CurrentState == newState) return;
            PlayerAnimator.Play(newState.ToString());
            CurrentState = newState;
        }
    
        private void Update() {
            float moveDirection = MovementController.get_MoveDirection;
            bool isGrounded = MovementController.get_IsGrounded;
            bool isJumping = MovementController.get_IsJumping;
            if (isGrounded) {
                if (moveDirection != 0) {
                    PlayerSprite.flipX = moveDirection < 0;
                    ChangeAnimationState(PlayerState.Run);
                }
                else {
                    ChangeAnimationState(PlayerState.Idle);
                }   
            } else {
                PlayerSprite.sprite = playerJumpSprite;
                ChangeAnimationState(PlayerState.Jump);
                PlayerSprite.flipX = moveDirection < 0;
            }
        }
    }
}