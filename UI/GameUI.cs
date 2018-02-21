using Mine.unity.Managers;
using UnityEngine;

namespace Mine.UI
{
    public class GameUI
    {
        private Canvas m_canvas;

        public Transform EntitiesContainer { get; private set; }
        public Transform UIContainer { get; private set; }


        private PlayerOreStorage m_storage;

        public GameUI(PlayerOreStorage storage)
        {
            m_canvas = GameObject.Instantiate(Resources.Load<Canvas>("Prefabs/UI/GameCanvas"));
            EntitiesContainer = m_canvas.transform.Find("Entities");
            UIContainer = m_canvas.transform.Find("UI Elements");

            m_storage = storage;
            CreateUI();
        }

        private OreUI m_oreUI;
        private CurrencyUI m_currencyUi;

        private void CreateUI()
        {
            m_currencyUi = new CurrencyUI(this, m_storage);
            m_oreUI = new OreUI(this, m_storage);
        }

        public void UpdateUI()
        {
            m_currencyUi.Update();
            m_oreUI.Update();
        }
    }
}