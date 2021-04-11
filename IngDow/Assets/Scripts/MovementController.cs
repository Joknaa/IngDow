using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    private Rigidbody2D Rigid2D;
    private AnimationController AnimationController;
    public float Speed = 4f;
    public float FullJumpHeight = 3f;
    public float FullJumpFallSpeed;
    public float CutJumpHeight;
    public bool IsGrounded = true;
    public float xAxis;
    public bool JumpRegistered;


    private void Start() {
        Rigid2D = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<AnimationController>();
    }

    private void Update() {
        xAxis = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        Move();
        JumpLower();
        JumpHigher();
        FallFaster();
    }

    private void Move() {
        if (xAxis == 0) return;
        var movement = new Vector3(xAxis, 0f, 0f);
        Rigid2D.MovePosition(transform.position + Speed * Time.deltaTime * movement);
    }
    private void JumpLower() {
        if (!Input.GetKeyUp(KeyCode.Space)) return;
        if (!(Rigid2D.velocity.y > 0)) return;
        var Velocity = Rigid2D.velocity;
        Velocity = new Vector2(Velocity.x, Velocity.y * CutJumpHeight);
        Rigid2D.velocity = Velocity;
    }
    private void JumpHigher() {
        if (!Input.GetKeyDown(KeyCode.Space) || !IsGrounded) return;
        AnimationController.ChangeAnimationState(PlayerState.Jump);
        Rigid2D.AddForce(new Vector2(0f, FullJumpHeight), ForceMode2D.Impulse);
    }
    private void FallFaster() {
        if (Rigid2D.velocity.y < 0) {
            Rigid2D.velocity += Physics2D.gravity.y * FullJumpFallSpeed * Time.deltaTime * Vector2.up;
        }
    }
}
