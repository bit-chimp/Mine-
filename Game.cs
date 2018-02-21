using Mine.unity.Managers;
using Mine.UI;
using UnityEngine;

namespace Mine.unity
{
    public class Game : MonoBehaviour
    {

        private CollectionManager m_collectionManager;
        private PlayerOreStorage m_playerOreStorage;

        private GameUI m_gameUi;
        private void Awake()
        {
            m_playerOreStorage = new PlayerOreStorage();
            m_collectionManager = new CollectionManager(m_playerOreStorage);
            
            m_gameUi = new GameUI(m_playerOreStorage);
        }

        private void Update()
        {
            m_gameUi.UpdateUI();

            if (Input.GetKeyUp(KeyCode.Space))
            {
                m_playerOreStorage.SellOre();
            }
        }
    }
}