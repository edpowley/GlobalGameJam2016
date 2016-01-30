using UnityEngine;
using System.Collections;

public class SandBlock : MonoBehaviour {

	public float m_probDissolvePerFrame = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		if (Earthquake.IsQuaking && Random.value < 0.01f) {
			Destroy(this.gameObject);
		}
	}


}
