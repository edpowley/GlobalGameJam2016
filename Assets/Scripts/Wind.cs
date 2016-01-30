using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	private Rigidbody2D m_body;

	internal static bool IsBlowing { get; set; }
	internal static Vector2 BlowDirection { get; set; }

	// Use this for initialization
	void Start () {
		m_body = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		if (IsBlowing) {
			m_body.AddForce(BlowDirection * GameManager.Instance.m_windStrength);
		}
	}
}
