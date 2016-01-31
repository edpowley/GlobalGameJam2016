using UnityEngine;
using System.Collections;
using System.Linq;

public class Flammable : MonoBehaviour
{
    public GameObject m_particleSystemPrefab;

    private bool m_isOnFire = false;

    public bool m_isDirectlyIgnitable = true;
    public float m_igniteTime = 3;
    public float m_burnTime = 3;

    private float m_igniteCountDown = float.PositiveInfinity;

    private BreakablePart m_breakablePart;

    internal IEnumerator burn()
    {
        if (!m_isOnFire)
        {
            m_isOnFire = true;

            if (m_breakablePart != null)
            {
                foreach (var neighbour in m_breakablePart.m_neighbours)
                {
                    Flammable neighbourFlammable = null;
                    try
                    {
                        neighbourFlammable = neighbour.GetComponent<Flammable>();
                    }
                    catch (MissingReferenceException)
                    {
                    }

                    if (neighbourFlammable != null && !neighbourFlammable.m_isOnFire && neighbourFlammable.m_igniteCountDown > neighbourFlammable.m_igniteTime)
                    {
                        neighbourFlammable.m_igniteCountDown = neighbourFlammable.m_igniteTime;
                    }
                }
            }

            ParticleSystem particleSystem = (Instantiate(m_particleSystemPrefab) as GameObject).GetComponent<ParticleSystem>();
            particleSystem.transform.position = transform.position;

            while (m_burnTime > 0)
            {
                yield return null;
                m_burnTime -= Time.deltaTime;
                particleSystem.transform.position = transform.position;
            }

            Destroy(this.gameObject);
            particleSystem.enableEmission = false;

            yield return new WaitForSeconds(particleSystem.startLifetime);
            Destroy(particleSystem.gameObject);
        }
    }

    void Start()
    {
        m_breakablePart = GetComponent<BreakablePart>(); // could be null
    }

    void Update()
    {
        if (!m_isOnFire && m_isDirectlyIgnitable)
        {
            FireCircle fireCircle = PlayerMovement.Instance.m_fireCircle;
            if (fireCircle != null)
            {
                float distance = Vector3.Distance(transform.position, fireCircle.transform.position);
                if (Mathf.Abs(distance - fireCircle.m_radius) < 0.5f)
                {
                    StartCoroutine(burn());
                }
            }
        }

        if (!m_isOnFire)
        {
            m_igniteCountDown -= Time.deltaTime;
            if (m_igniteCountDown <= 0)
            {
                StartCoroutine(burn());
            }
        }
    }
}
