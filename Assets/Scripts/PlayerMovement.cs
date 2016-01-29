using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	// The physics body
	private Rigidbody2D m_body;

	// Ground detector for jumping
	public PlayerGroundDetector m_groundDetector;

	// Character horizontal movement speed
	public float m_movementSpeed = 10;

	// Character horizontal friction
	public float m_movementFriction = 5;

	// Upward force from jumping
	public float m_jumpStrength = 1000;

	void Start()
	{
		// Store a reference to the physics body
		m_body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			// Move left
			m_body.AddForce (Vector2.left * m_movementSpeed);
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			// Move right
			m_body.AddForce (Vector2.right * m_movementSpeed);
		} else {
			// If not pressing a key, add friction force
			m_body.AddForce(new Vector2(-m_body.velocity.x * m_movementFriction, 0));
		}

		if (m_groundDetector.IsOnGround && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space))) {
			// Jump
			m_body.AddForce (Vector2.up * m_jumpStrength);
		}
	}

	// Update is called once per frame
	void Update()
	{
	
	}
}
