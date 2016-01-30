using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform m_target;
	public float m_minX, m_maxX, m_minY, m_maxY;
	public float m_thresholdX = 2;
	public float m_thresholdY = 1;
	public float m_lerpFactor = 0.5f;
	public Vector3 m_shakeAmount;

	// Use this for initialization
	void Start ()
	{
		
	}

	private float getMoveToPos(float currentPos, float targetPos, float threshold)
	{
		float diff = targetPos - currentPos;
		if (Mathf.Abs (diff) < threshold)
			return currentPos;
		else
			return currentPos + Mathf.Sign(diff) * (Mathf.Abs(diff) - threshold);
	}

	void LateUpdate ()
	{
		float moveToX = getMoveToPos (transform.position.x, m_target.transform.position.x, m_thresholdX);
		moveToX = Mathf.Clamp (moveToX, m_minX, m_maxX);
		float moveToY = getMoveToPos (transform.position.y, m_target.transform.position.y, m_thresholdY);
		moveToY = Mathf.Clamp (moveToY, m_minY, m_maxY);

		transform.position = Vector3.Lerp(transform.position, new Vector3 (moveToX, moveToY, transform.position.z), m_lerpFactor);

		if (Earthquake.IsQuaking) {
			Vector3 shake = Random.insideUnitSphere;
			transform.position += new Vector3 (
				shake.x * m_shakeAmount.x,
				shake.y * m_shakeAmount.y,
				shake.z * m_shakeAmount.z);
		}
	}
}
