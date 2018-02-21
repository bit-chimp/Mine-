using Mine.unity.Managers;
using Mine.UI;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyUI
{
    private PlayerOreStorage m_store;
    private UI_SimpleIconText m_ui;

    public CurrencyUI(GameUI ui, PlayerOreStorage store)
    {
        m_store = store;

        m_ui = GameObject.Instantiate(Resources.Load<UI_SimpleIconText>("Prefabs/UI/ui_simple_icon_text"));
        m_ui.SetText("0");
        m_ui.SetIcon("Sprites/UI/Currency/gui_currency_ore_back");
        m_ui.transform.SetParent(ui.UIContainer, false);
        m_ui.transform.localPosition = new Vector3(-320.4f, 173, 0);
    }

    public void Update()
    {
        m_ui.SetText(m_store.GetCollectedOre().Count.ToString());
    }
}