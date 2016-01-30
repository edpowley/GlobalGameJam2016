using UnityEngine;
using System.Collections;

public class SandBlock : MonoBehaviour {

	public float m_probDissolvePerFrame = 0.01f;
	public GameObject m_dissolveParticleSystemPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		if (Earthquake.IsQuaking && Random.value < 0.01f) {
			StartCoroutine(spawnDissolveParticles());
			Destroy(this.gameObject);
		}
	}

	private IEnumerator spawnDissolveParticles() {
		GameObject particleSystem = (GameObject)Instantiate (m_dissolveParticleSystemPrefab);
		particleSystem.transform.position = this.transform.position;

		yield return new WaitForSeconds (particleSystem.GetComponent<ParticleSystem> ().startLifetime);

		Destroy (particleSystem);
	}
}
