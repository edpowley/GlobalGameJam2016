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
            {
                try
                {
                    var unused = part.transform;
                    parts.Add(part);
                }
                catch (MissingReferenceException)
                {
                    Debug.Log("hi");
                }
            }
        }

        if (parts.Count == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            foreach (BreakablePart part in parts.First().getConnectedParts())
            {
                bool result = parts.Remove(part);
                if (!result)
                {
                    Debug.LogWarningFormat("Found a part not in the children of this BreakableBody (A) : {0}", part);
                }
            }

            while (parts.Count > 0)
            {
				GameObject newBody = (GameObject)Instantiate(this.gameObject, this.transform.position, this.transform.rotation);

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
                    bool result = parts.Remove(part);
                    if (!result)
                    {
                        Debug.LogWarningFormat("Found a part not in the children of this BreakableBody (B) : {0}", part);
                    }

                }

                newBody.GetComponent<BreakableBody>().checkAnchorStatus();
            }

            checkAnchorStatus();
        }
    }
}
