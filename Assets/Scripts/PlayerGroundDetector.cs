using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGroundDetector : MonoBehaviour {

	internal List<Collider2D> m_contactedColliders = new List<Collider2D>();

	// Get whether the player is stood on the ground
	internal bool IsOnGround { get { return m_contactedColliders.Count > 0; } }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.isTrigger) { // Don't register contact with triggers
			if (!m_contactedColliders.Contains(coll))
				m_contactedColliders.Add(coll);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (!coll.isTrigger) { // Don't register contact with triggers
			bool result = m_contactedColliders.Remove(coll);
			if (!result)
				Debug.LogWarning("Exited a collider that wasn't entered");
		}
	}

	void Update() {
		for (int i=0; i<m_contactedColliders.Count; i++) {
			if (m_contactedColliders [i] == null) {
				m_contactedColliders.RemoveAt (i);
				i--;
			} else {
				try {
					var unused = m_contactedColliders [i].attachedRigidbody;
				} catch (MissingReferenceException) {
					Debug.LogWarning ("Collider is in m_contactedColliders but has been destroyed");
					m_contactedColliders.RemoveAt (i);
					i--;
				}
			}
		}

		foreach (Collider2D coll in m_contactedColliders) {
			Debug.DrawLine(transform.position, coll.transform.position, Color.magenta);
		}
	}
}
