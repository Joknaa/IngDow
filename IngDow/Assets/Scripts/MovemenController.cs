using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemenController : MonoBehaviour {
    public float Speed = 5f;
    public float JumpHeight = 3f;
    public bool IsGrounded;
    
    private void Update()
    {
        Jump();
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Speed * Time.deltaTime * movement;
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
        }
    }
}
