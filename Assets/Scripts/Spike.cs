using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player" && !coll.isTrigger) {
			GameManager.Instance.killPlayer();
		}
	}

}
