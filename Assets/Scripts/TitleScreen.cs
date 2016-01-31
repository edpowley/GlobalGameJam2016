using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public TitleScreenInfoPanel m_infoPanel;

    public TextAsset m_controlsText, m_storyText, m_creditsText;

	public void OnPlayButton()
    {
        Application.LoadLevel(1);
    }

    public void OnControlsButton()
    {
        m_infoPanel.ShowWithText(m_controlsText.text);
    }

    public void OnStoryButton()
    {
        m_infoPanel.ShowWithText(m_storyText.text);
    }

    public void OnCreditsButton()
    {
        m_infoPanel.ShowWithText(m_creditsText.text);
    }
}
