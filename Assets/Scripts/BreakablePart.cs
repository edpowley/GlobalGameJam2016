using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakablePart : MonoBehaviour {

    public List<BreakablePart> m_neighbours = new List<BreakablePart>();

    public bool m_isAnchor = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        foreach (BreakablePart neighbour in m_neighbours)
        {
            neighbour.m_neighbours.Remove(this);
        }
    }

    internal IEnumerable<BreakablePart> getConnectedParts()
    {
        HashSet<BreakablePart> seen = new HashSet<BreakablePart>();
        seen.Add(this);
        Stack<BreakablePart> todo = new Stack<BreakablePart>();
        todo.Push(this);

        while (todo.Count > 0)
        {
            BreakablePart part = todo.Pop();

            foreach(BreakablePart neighbour in part.m_neighbours)
            {
                if (!seen.Contains(neighbour))
                {
                    seen.Add(neighbour);
                    todo.Push(neighbour);
                }
            }
        }

        return seen;
    }
}
