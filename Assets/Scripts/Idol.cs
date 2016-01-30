using UnityEngine;
using System.Collections;

public class Idol : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
}
