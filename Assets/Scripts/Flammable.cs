using UnityEngine;
using System.Collections;

public class Flammable : MonoBehaviour
{
	public GameObject m_particleSystemPrefab;

	private bool m_isOnFire = false;

	public bool m_isDirectlyIgnitable = true;
	public float m_burnTimeMean = 3;
	public float m_burnTimeRange = 1;

	internal IEnumerator burn() {
		m_isOnFire = true;

		ParticleSystem particleSystem = (Instantiate (m_particleSystemPrefab) as GameObject).GetComponent<ParticleSystem>();
		particleSystem.transform.position = transform.position;

		float burnTime = m_burnTimeMean + Random.Range (-1, +1) * m_burnTimeRange;

		while (burnTime > 0) {
			yield return null;
			burnTime -= Time.deltaTime;
			particleSystem.transform.position = transform.position;
		}

		Destroy (this.gameObject);
		particleSystem.enableEmission = false;

		yield return new WaitForSeconds(particleSystem.startLifetime);
		Destroy (particleSystem.gameObject);

	}

	void Update() {

		if (!m_isOnFire && m_isDirectlyIgnitable) {
			FireCircle fireCircle = PlayerMovement.Instance.m_fireCircle;
			if (fireCircle != null) {
				float distance = Vector3.Distance(transform.position, fireCircle.transform.position);
				if (Mathf.Abs(distance - fireCircle.m_radius) < 0.5f) {
					StartCoroutine(burn ());
				}
			}
		}
	}

}
