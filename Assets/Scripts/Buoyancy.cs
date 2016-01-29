using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {

	public float m_buoyancyForce = 10;

	// The physics body
	private Rigidbody2D m_body;

	void Start() {
		m_body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float yDiff = transform.position.y - Water.Instance.WaterLevel;
		if (yDiff < 0) {
			m_body.AddForce(Vector2.up * m_buoyancyForce * -yDiff);
		}
	}
}
