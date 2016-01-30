using UnityEngine;
using System.Collections;

public class BobUpAndDown : MonoBehaviour {

	public float m_frequency = 1;
	public float m_amount = 0.2f;

	private float m_phase, m_centreY;

	// Use this for initialization
	void Start ()
	{
		m_phase = Random.Range (0, 2 * Mathf.PI);
		m_centreY = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localPosition = new Vector3(transform.localPosition.x, m_centreY + m_amount * Mathf.Sin(m_phase), transform.localPosition.z);

		m_phase += Time.deltaTime * 2 * Mathf.PI * m_frequency;
		while (m_phase > 2 * Mathf.PI)
			m_phase -= 2 * Mathf.PI;
	}
}
