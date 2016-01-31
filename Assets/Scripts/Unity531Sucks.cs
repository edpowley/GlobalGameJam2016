using UnityEngine;
using System.Collections;

// Workaround for a stupid bug in Unity 5.3.1f1
// See http://forum.unity3d.com/threads/unity-5-3-1f1-particle-system-errors-invalid-aabb-result-isfinite-d.374926/#post-2429887

[ExecuteInEditMode]
public class Unity531Sucks : MonoBehaviour
{
    ParticleSystem.Particle[] unused = new ParticleSystem.Particle[1];

    void Awake()
    {
        GetComponent<ParticleSystemRenderer>().enabled = false;
    }

    void LateUpdate()
    {
        GetComponent<ParticleSystemRenderer>().enabled = GetComponent<ParticleSystem>().GetParticles(unused) > 0;
    }
}
