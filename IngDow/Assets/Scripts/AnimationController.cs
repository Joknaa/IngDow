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
    private MovemenController MovementController;

    private void Start() {
        PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        MovementController = GetComponent<MovemenController>();
    }

    public void ChangeAnimationState(PlayerState newState) {
        if (CurrentState == newState) return;
        PlayerAnimator.Play(newState.ToString());
        CurrentState = newState;
    }
    
    private void FixedUpdate() {
        if (MovementController.IsGrounded) {
            if (MovementController.xAxis != 0) {
                ChangeAnimationState(PlayerState.Run);
                PlayerSprite.flipX = MovementController.xAxis < 0;
            } else if (MovementController.JumpRegistered) {
                ChangeAnimationState(PlayerState.Jump);
            }else {
                ChangeAnimationState(PlayerState.Idle);
            }
        }
        
    }
}
