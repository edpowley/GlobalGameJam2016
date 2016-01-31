using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	internal static GameManager Instance { get; private set; }

	public bool m_cheatMode = false;

	public float m_windStrength = 50;

	public float m_earthquakeHeight = 5;

	public ParticleSystem m_rainParticleSystem;
	public ParticleSystem m_windParticleSystem;

	internal Dictionary<PickupType, int> m_inventory = new Dictionary<PickupType, int>() {
		{ PickupType.Earth, 0 },
		{ PickupType.Wind, 0 },
		{ PickupType.Fire, 0 },
		{ PickupType.Water, 0 }
	};

	void Awake() {
		Instance = this;
	}

	void OnDestroy() {
		if (Instance == this) {
			Instance = null;
		}
	}
	void Start() {
		Wind.IsBlowing = false;
		Earthquake.IsQuaking = false;

		//m_rainParticleSystem.enableEmission = false;
		//m_windParticleSystem.enableEmission = false;
	}

	void Update() {
		// Cheat
		if (m_cheatMode && Input.GetKeyDown (KeyCode.C)) {
			foreach(PickupType pickup in System.Enum.GetValues(typeof(PickupType))) {
				GameManager.Instance.m_inventory[pickup] ++;
			}
		}
	}

	internal void killPlayer() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
