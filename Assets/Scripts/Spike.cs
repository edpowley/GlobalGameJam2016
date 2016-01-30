using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			GameManager.Instance.killPlayer();
		}
	}

}
