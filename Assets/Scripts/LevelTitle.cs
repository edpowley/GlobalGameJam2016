using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTitle : MonoBehaviour
{
    public float m_typeDelay = 0.1f;
    public float m_preFadeTime = 2;
    public float m_fadeTime = 2;

    static private int m_lastLevel = -1;

    // Use this for initialization
    IEnumerator Start()
    {
        if (Application.loadedLevel != m_lastLevel)
        {
            m_lastLevel = Application.loadedLevel;

            Text textBox = GetComponent<Text>();
            string text = string.Format("Level {0}\n{1}", Application.loadedLevel + 1, Application.loadedLevelName);

            for (int i = 0; i < text.Length; i++)
            {
                textBox.text = text.Substring(0, i + 1);
                yield return new WaitForSeconds(m_typeDelay);
            }


            yield return new WaitForSeconds(m_preFadeTime);

            textBox.CrossFadeAlpha(0, m_fadeTime, true);
            yield return new WaitForSeconds(m_fadeTime);
        }

        gameObject.SetActive(false);
    }
}
