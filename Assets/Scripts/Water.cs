using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	internal static Water Instance { get; private set; }

	void Awake() {
		Instance = this;
	}
	
	void OnDestroy() {
		if (Instance == this) {
			Instance = null;
		}
	}

	// Get the surface level of the water
	internal float WaterLevel { 
		get {
			return transform.position.y + 0.5f * transform.localScale.y; 
		}
		set {
			//if (value > 5) 
			//	value = 5;

			transform.position = new Vector3 (transform.position.x, value - 0.5f * transform.localScale.y, transform.position.z);
		}
	}

}
