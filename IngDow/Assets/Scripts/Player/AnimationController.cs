using Player;
using UnityEngine;

public enum PlayerState {
    Idle,
    Jump,
    Walk,
    Run
}
public class AnimationController : MonoBehaviour {
    private SpriteRenderer PlayerSprite;
    private Animator PlayerAnimator;
    private PlayerState CurrentState;
    private MovementController MovementController;
    private CharacterController2D CharacterController2D;

    private void Start() {
        PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        MovementController = GetComponent<MovementController>();
        CharacterController2D = GetComponent<CharacterController2D>();
    }

    public void ChangeAnimationState(PlayerState newState) {
        if (CurrentState == newState) return;
        PlayerAnimator.Play(newState.ToString());
        CurrentState = newState;
    }
    
    private void Update() {
        if (CharacterController2D.IsGrounded) {
            if (MovementController.xAxis != 0) {
                PlayerSprite.flipX = MovementController.xAxis < 0;
                ChangeAnimationState(PlayerState.Run);
            }
            else {
                ChangeAnimationState(PlayerState.Idle);
            }

            if (MovementController.Jump) {
                ChangeAnimationState(PlayerState.Jump);
            }
        } else {
            PlayerSprite.flipX = MovementController.xAxis < 0;
        }

        
    }
}
