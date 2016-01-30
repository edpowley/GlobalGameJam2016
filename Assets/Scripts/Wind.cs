using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	private Rigidbody2D m_body;
	private RigidbodyConstraints2D m_constraintsWhenNotBlowing;
	public RigidbodyConstraints2D m_constraintsWhenBlowing;

	internal static bool IsBlowing { get; set; }
	internal static Vector2 BlowDirection { get; set; }

	// Use this for initialization
	void Start () {
		m_body = GetComponent<Rigidbody2D> ();
		m_constraintsWhenNotBlowing = m_body.constraints;
	}

	// TODO: make objects come to a gradual halt when wind stops

	void FixedUpdate() {
		if (IsBlowing) {
			m_body.constraints = m_constraintsWhenBlowing;
			m_body.AddForce (BlowDirection * GameManager.Instance.m_windStrength);
		} else {
			m_body.constraints = m_constraintsWhenNotBlowing;
		}
	}
}
