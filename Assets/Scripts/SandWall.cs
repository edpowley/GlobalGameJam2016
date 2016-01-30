using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SandWall : MonoBehaviour
{
	public int m_width = 1;
	public int m_height = 1;

	public GameObject m_brickPrefab;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void BuildObject()
	{
		List<Transform> children = new List<Transform> ();
		foreach (Transform child in this.transform) {
			children.Add(child);
		}

		Debug.LogFormat ("Removing {0} children", children.Count);

		foreach (Transform child in children) {
			DestroyImmediate(child.gameObject);
		}

		GameObject[,] bricks = new GameObject[m_width, m_height];

		for (int y=0; y<m_height; y++) {
			for (int x=0; x<m_width; x++) {
				Vector3 pos = new Vector3(x - (m_width-1)*0.5f, y - (m_height-1)*0.5f, 0);
				GameObject brick = (GameObject)Instantiate(m_brickPrefab, pos, Quaternion.identity);
				brick.transform.SetParent(this.transform, false);
				brick.name = string.Format("Brick {0},{1}", x, y);
				bricks[x, y] = brick;

				if (x > 0) {
					addJoint(brick, bricks[x-1, y]);
				}

				if (y > 0) {
					addJoint(brick, bricks[x, y-1]);
				}
			}
		}
	}

	private void addJoint(GameObject brick1, GameObject brick2) {
		DistanceJoint2D joint = brick1.AddComponent<DistanceJoint2D> ();
		joint.connectedBody = brick2.GetComponent<Rigidbody2D> ();
		joint.enableCollision = true;
	}
}
