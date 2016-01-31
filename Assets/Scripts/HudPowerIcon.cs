using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudPowerIcon : MonoBehaviour
{
    public PickupType m_pickupType;
    public Text m_text;
    public Image m_image;
    public Color m_activeColour = new Color(1, 1, 1, 1);
    public Color m_inactiveColour = new Color(1, 1, 1, 0.25f);

    // Update is called once per frame
    void Update()
    {
        int n = GameManager.Instance.m_inventory[m_pickupType];
        m_text.text = n.ToString();
        m_image.color = (n > 0) ? m_activeColour : m_inactiveColour;
    }
}
