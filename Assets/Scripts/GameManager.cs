using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	internal static GameManager Instance { get; private set; }

	internal Dictionary<PickupType, int> m_inventory = new Dictionary<PickupType, int>() {
		{ PickupType.Earth, 0 },
		{ PickupType.Wind, 0 },
		{ PickupType.Fire, 0 },
		{ PickupType.Water, 0 }
	};

	void Awake() {
		Instance = this;
	}

	void Start() {

	}
}
