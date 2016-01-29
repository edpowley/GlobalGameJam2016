using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
	public PickupType m_pickupType;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.isTrigger && coll.tag == "Player") {
			GameManager.Instance.m_inventory[m_pickupType]++;
			Destroy(this.gameObject);
		}
	}
}
