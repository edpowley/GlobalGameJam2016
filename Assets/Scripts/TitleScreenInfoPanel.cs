using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenInfoPanel : MonoBehaviour
{
    public float m_typeDelay = 1.0f / 30.0f;
    public Text m_textBox;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnOK()
    {
        gameObject.SetActive(false);
    }

    internal void ShowWithText(string text)
    {
        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(typeText(text));
    }

    private IEnumerator typeText(string text)
    {
        for(int i=0;i<text.Length;i++)
        {
            m_textBox.text = text.Substring(0, i + 1);
            yield return new WaitForSeconds(m_typeDelay);
        }
    }
}
