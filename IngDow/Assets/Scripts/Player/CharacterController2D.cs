using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
	[SerializeField] private bool AirControl = false;

	public bool IsGrounded = true;           
	private Rigidbody2D Rigid;
	private Vector3 Velocity = Vector3.zero;

	private void Awake() {
		Rigid = GetComponent<Rigidbody2D>();
	}

	public void Move(float move, bool jump) {
		if (IsGrounded || AirControl) {
			Vector3 targetVelocity = new Vector2(move * 10f, Rigid.velocity.y);
			Rigid.velocity = Vector3.SmoothDamp(Rigid.velocity, targetVelocity, ref Velocity, MovementSmoothing);
		}

		if (!IsGrounded || !jump) return;
		IsGrounded = false;
		Rigid.AddForce(new Vector2(0f, JumpForce));
	}
}
