using UnityEngine;
using System.Collections;

public class Earthquake : MonoBehaviour {

	internal static Earthquake Instance { get; private set; }

	internal static bool IsQuaking { get; set; }

	void Awake() {
		Instance = this;
	}
	
	void OnDestroy() {
		if (Instance == this) {
			Instance = null;
		}
	}


}
