using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	private float inputAxis;
	private Vector2 velocity;

	public float moveSpeed = 8f;
	public float friction = 1f;
	public float maxJumpHeight = 5f;
	public float maxJumpTime = 1f;
	
	public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
	public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

	public bool grounded { get; private set; }
	public bool jumping { get; private set; }

	public Animator animator;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		HorizontalMovement();

		animator.SetFloat("Direction", inputAxis);
		animator.SetFloat("Moving", Mathf.Abs(velocity.x));
		animator.SetBool("Jumping", jumping);

		grounded = rb.Raycast(Vector2.down);

		if (grounded) 
		{
			GroundedMovement();
		}

		ApplyGravity();
	}
	
	private void HorizontalMovement()
	{
		inputAxis = Input.GetAxis("Horizontal");
		velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, friction * Time.deltaTime);

		if (rb.Raycast(Vector2.right * velocity.x))
		{
			velocity.x = 0f;
		}
	}

	private void GroundedMovement()
	{
		velocity.y = Mathf.Max(velocity.y, 0f);
		jumping = velocity.y > 0f;

		if (Input.GetButtonDown("Jump"))
		{
			velocity.y = jumpForce;
			jumping = true;
		}
	}

	private void ApplyGravity()
	{
		bool falling = velocity.y < 0f || !Input.GetButton("Jump");
		float multiplier = falling ? 2f : 1f;

		velocity.y += gravity * multiplier * Time.deltaTime;
		velocity.y = Mathf.Max(velocity.y, gravity / 2f);
	}

	private void FixedUpdate()
	{
		Vector2 position = rb.position;
		position += velocity * Time.fixedDeltaTime;
		rb.MovePosition(position);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("Collectibles"))
		{
			if (transform.DotTest(collision.transform, Vector2.up))
			{
				velocity.y = 0f;
			}
		}
	}

}
