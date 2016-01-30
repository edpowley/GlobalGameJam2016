using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireCircle : MonoBehaviour {

	private bool m_isAlive = true;
	public float m_speed = 1;
	internal float m_radius { get; private set; }

	public GameObject m_particleSystemPrefab;

	private List<GameObject> m_particleSystems = new List<GameObject>();

	// Update is called once per frame
	void Update () {
		if (m_isAlive) {
			m_radius += Time.deltaTime * m_speed;

			int numEmitters = Mathf.CeilToInt (Mathf.Max (2 * Mathf.PI * m_radius, 6));
			while (m_particleSystems.Count < numEmitters) {
				GameObject newObject = (GameObject)Instantiate (m_particleSystemPrefab);
				newObject.transform.SetParent (this.transform, false);
				int insertIndex = (m_particleSystems.Count > 0) ? Mathf.FloorToInt (Random.Range (0, m_particleSystems.Count - 0.1f)) : 0;
				m_particleSystems.Insert (insertIndex, newObject);
			}

			for (int i=0; i<m_particleSystems.Count; i++) {
				float angle = 2 * Mathf.PI / m_particleSystems.Count * i;
				m_particleSystems [i].transform.localPosition = m_radius * new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0);
			}
		}
	}

	internal void kill() {
		StartCoroutine (coroutineKill ());
	}

	private IEnumerator coroutineKill()	{
		m_isAlive = false;
		float waitTime = 0;
		foreach (var ps in m_particleSystems) {
			ps.GetComponent<ParticleSystem>().enableEmission = false;
			if (waitTime == 0)
				waitTime = ps.GetComponent<ParticleSystem>().startLifetime;
		}

		yield return new WaitForSeconds (waitTime);

		Destroy (this.gameObject);
	}
}
