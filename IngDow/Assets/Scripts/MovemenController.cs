using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemenController : MonoBehaviour {
    private Rigidbody2D Rigid2D;
    public float Speed = 4f;
    public float FullJumpHeight = 3f;
    public float FullJumpFallSpeed;
    public float CutJumpHeight;
    public float QuickJumpFallSpeed;
    public float JumpPress_TimeWindow = 0.2f;
    public float Grounded_TimeWindow = 0.1f;
    public bool IsGrounded;
    private float JumpButton_PressedTime = 0f;
    private float Grounded_PressedTime = 0f;

    private void Start() {
        Rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Move();
        UpdateJumpTimer();
        UpdateGroundTimer();
        JumpLower();
        JumpHigher();
        FallFaster();
    }

    private void FallFaster() {
        if (Rigid2D.velocity.y < 0) {
            Rigid2D.velocity += Physics2D.gravity.y * FullJumpFallSpeed * Time.deltaTime * Vector2.up;
        }
    }

    private void Move() {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Speed * Time.deltaTime * movement;
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
        var JumpRegistered = JumpButton_PressedTime < JumpPress_TimeWindow;
        var StillGrounded = Grounded_PressedTime < Grounded_TimeWindow;
        
        if (!JumpRegistered || !StillGrounded) return;
        JumpButton_PressedTime = JumpPress_TimeWindow;
        Grounded_PressedTime = Grounded_TimeWindow;
        Rigid2D.velocity = FullJumpHeight * Vector2.up;
        //Rigid2D.AddForce(new Vector2(0f, FullJumpHeight), ForceMode2D.Impulse);
    }
}
