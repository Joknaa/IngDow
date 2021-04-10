using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemenController : MonoBehaviour {
    private Rigidbody2D Rigid2D;
    private AnimationController AnimationController;
    public float Speed = 4f;
    public float FullJumpHeight = 3f;
    public float FullJumpFallSpeed;
    public float CutJumpHeight;
    public float JumpPress_TimeWindow = 0.2f;
    public float Grounded_TimeWindow = 0.1f;
    private float JumpButton_PressedTime = 0f;
    private float Grounded_PressedTime = 0f;
    public bool IsGrounded;
    public bool StillGrounded;
    public float xAxis;
    public bool JumpRegistered;


    private void Start() {
        Rigid2D = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<AnimationController>();
    }

    private void Update() {
        xAxis = Input.GetAxis("Horizontal");
        
        UpdateJumpTimer();
        UpdateGroundTimer();
    }

    private void FixedUpdate() {
        Move();
        JumpLower();
        JumpHigher();
        FallFaster();
    }

    private void Move() {
        var movement = new Vector3(xAxis, 0f, 0f);
        Rigid2D.MovePosition(transform.position + Speed * Time.deltaTime * movement);
    }
    private void UpdateGroundTimer() {
        Grounded_PressedTime += Time.deltaTime;
        if (!IsGrounded) return;
        Grounded_PressedTime = 0f;
    }
    private void UpdateJumpTimer() {
        JumpButton_PressedTime += Time.deltaTime;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        JumpButton_PressedTime = 0f;
    }
    private void JumpLower() {
        if (!Input.GetKeyUp(KeyCode.Space)) return;
        if (!(Rigid2D.velocity.y > 0)) return;
        var PlayerVelocity = Rigid2D.velocity;
        PlayerVelocity = new Vector2(PlayerVelocity.x, PlayerVelocity.y * CutJumpHeight);
        Rigid2D.velocity = PlayerVelocity;
    }
    private void JumpHigher() { 
        //JumpRegistered = JumpButton_PressedTime < JumpPress_TimeWindow;
        //StillGrounded = Grounded_PressedTime < Grounded_TimeWindow;
        //if (!JumpRegistered || !StillGrounded) return;
        if (!Input.GetKeyDown(KeyCode.Space) || !IsGrounded) return;
        //JumpButton_PressedTime = JumpPress_TimeWindow;
        //Grounded_PressedTime = Grounded_TimeWindow;
        //Rigid2D.velocity = FullJumpHeight * Vector2.up;
        AnimationController.ChangeAnimationState(PlayerState.Jump);
        Rigid2D.AddForce(new Vector2(0f, FullJumpHeight), ForceMode2D.Impulse);
    }
    private void FallFaster() {
        if (Rigid2D.velocity.y < 0) {
            Rigid2D.velocity += Physics2D.gravity.y * FullJumpFallSpeed * Time.deltaTime * Vector2.up;
        }
    }
}
