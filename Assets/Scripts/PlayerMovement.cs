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

	public float m_waterRaiseAmount = 1;

	public float m_headHeight = 1;

	void Start()
	{
		// Store a reference to the physics body
		m_body = GetComponent<Rigidbody2D> ();
	}

	void flipSprite()
	{
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void FixedUpdate()
	{
		float horizontalControl = 0;

		Vector2 groundVelocity = Vector2.zero;

		foreach (Collider2D coll in m_groundDetector.m_contactedColliders) {
			if (coll.attachedRigidbody != null)
				groundVelocity += coll.attachedRigidbody.velocity;
		}

		if (m_groundDetector.m_contactedColliders.Count > 0)
			groundVelocity /= m_groundDetector.m_contactedColliders.Count;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			horizontalControl = -1;
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			horizontalControl = +1;
		}

		//m_body.AddForce (Vector2.right * m_movementSpeed * horizontalControl);
		m_body.velocity = new Vector2(groundVelocity.x + m_movementSpeed * horizontalControl, m_body.velocity.y);

		// If facing the wrong direction, turn
		if (transform.localScale.x * horizontalControl < 0)
			flipSprite();

		if (m_groundDetector.IsOnGround && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Space))) {
			// Jump
			//m_body.AddForce (Vector2.up * m_jumpStrength);
			m_body.velocity = new Vector2(m_body.velocity.x, m_jumpStrength);
		}
	}

	private bool m_isRaisingWater = false;

	// Update is called once per frame
	void Update()
	{
		if (Water.Instance != null && transform.position.y + m_headHeight < Water.Instance.WaterLevel) {
			// You drowned!
			GameManager.Instance.killPlayer();
		}

		if (Input.GetKeyDown (KeyCode.Alpha1) && GameManager.Instance.m_inventory[PickupType.Water] > 0) {
			GameManager.Instance.m_inventory[PickupType.Water]--;
			m_isRaisingWater = true;
		}

		if (m_isRaisingWater) {
			Water.Instance.WaterLevel += m_waterRaiseAmount * Time.deltaTime;

			if (Input.GetKeyUp(KeyCode.Alpha1)) {
				m_isRaisingWater = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && GameManager.Instance.m_inventory [PickupType.Wind] > 0) {
			GameManager.Instance.m_inventory [PickupType.Wind]--;
			Wind.IsBlowing = true;
			Wind.BlowDirection = Vector2.right * Mathf.Sign(transform.localScale.x);
		}
		
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			Wind.IsBlowing = false;
		}

		if (Input.GetKeyDown (KeyCode.Alpha3) && GameManager.Instance.m_inventory [PickupType.Earth] > 0) {
			GameManager.Instance.m_inventory [PickupType.Earth]--;
			Earthquake.IsQuaking = true;
		}
		
		if (Input.GetKeyUp (KeyCode.Alpha3)) {
			Earthquake.IsQuaking = false;
		}
	}
}
