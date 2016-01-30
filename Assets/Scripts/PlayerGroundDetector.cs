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
}
