using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	internal static GameManager Instance { get; private set; }

	public UnityEngine.UI.Text m_placeholderHud;

	internal Dictionary<PickupType, int> m_inventory = new Dictionary<PickupType, int>() {
		{ PickupType.Earth, 0 },
		{ PickupType.Wind, 0 },
		{ PickupType.Fire, 0 },
		{ PickupType.Water, 0 }
	};

	void Awake() {
		Instance = this;
	}

	void Update() {
		m_placeholderHud.text = "";

		foreach (var kv in m_inventory) {
			m_placeholderHud.text += string.Format("{0} {1}\n", kv.Value, kv.Key);
		}
	}
}
