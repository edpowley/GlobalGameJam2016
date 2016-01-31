using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BreakableBody : MonoBehaviour
{

    private void checkAnchorStatus()
    {
        foreach (Transform child in this.transform)
        {
            BreakablePart part = child.GetComponent<BreakablePart>();
            if (part != null && part.m_isAnchor)
            {
                GetComponent<Rigidbody2D>().isKinematic = true;
                return;
            }
        }

        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void FixedUpdate()
    {
        HashSet<BreakablePart> parts = new HashSet<BreakablePart>();
        foreach (Transform child in this.transform)
        {
            BreakablePart part = child.GetComponent<BreakablePart>();
            if (part != null)
                parts.Add(part);
        }

        if (parts.Count == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            foreach (BreakablePart part in parts.First().getConnectedParts())
            {
                parts.Remove(part);
            }

            while (parts.Count > 0)
            {
                GameObject newBody = (GameObject)Instantiate(this.gameObject);

                // Remove all cloned children from new body
                List<Transform> children = new List<Transform>();
                foreach (Transform child in newBody.transform)
                    if (child.GetComponent<BreakablePart>() != null)
                        children.Add(child);
                foreach (Transform child in children)
                    DestroyImmediate(child.gameObject);

                // Add a connected group of children
                foreach (BreakablePart part in parts.First().getConnectedParts())
                {
                    part.transform.SetParent(newBody.transform, true);
                    parts.Remove(part);
                }

                newBody.GetComponent<BreakableBody>().checkAnchorStatus();
            }

            checkAnchorStatus();
        }
    }
}
