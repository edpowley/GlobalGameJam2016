using UnityEngine;
using System.Collections;

public class PlayerGroundDetector : MonoBehaviour {

	// Number of contacts with ground objects -- if >0 then we are on the ground
	private int m_numGroundContacts = 0;

	// Get whether the player is stood on the ground
	internal bool IsOnGround { get { return m_numGroundContacts > 0; } }

	void OnTriggerEnter2D(Collider2D coll)
	{
		m_numGroundContacts++;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		m_numGroundContacts--;
	}
}
