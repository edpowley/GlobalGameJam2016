using UnityEngine;
using System.Collections;

public class SpikeKiller : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{		
		if (coll.gameObject.tag == "Spike") {
			Destroy (coll.gameObject);
		}
	}
}
