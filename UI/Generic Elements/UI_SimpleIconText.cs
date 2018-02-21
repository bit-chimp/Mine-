using Mine.unity.Managers;
using UnityEngine;
using UnityEngine.UI;

public class UI_SimpleIconText : MonoBehaviour
{
    [SerializeField] private Text m_text;
    [SerializeField] private Image m_icon;

    public void SetText(string value)
    {
        m_text.text = value;
    }

    public void SetIcon(string path)
    {
        m_icon.sprite = Resources.Load<Sprite>(path);
        m_icon.SetNativeSize();
    }
}