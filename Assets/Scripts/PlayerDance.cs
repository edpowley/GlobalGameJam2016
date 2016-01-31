using UnityEngine;
using System.Collections;

public class PlayerDance : MonoBehaviour {

	public bool m_isWalking = false;
    public bool m_isDancing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (m_isDancing) {
			float zAngle = (Mathf.Sin (Time.time * 5) + Mathf.Sin (Time.time * 10)) * 3;
			transform.localRotation = Quaternion.Euler (0, 0, zAngle);

			transform.localPosition = new Vector3 (0, Mathf.Sin (Time.time * 15) * 0.02f, 0);
		} else if (m_isWalking) {
			float zAngle = Mathf.Sin (Time.time * 15) * 2;
			transform.localRotation = Quaternion.Euler (0, 0, zAngle);
			
			transform.localPosition = new Vector3 (0, Mathf.Sin (Time.time * 15) * 0.01f, 0);
		}
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, 0.1f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 0.1f);
		}
    }
}
