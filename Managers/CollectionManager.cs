using System.Collections.Generic;

namespace Mine.unity.Managers
{
    public class CollectionManager: IOreCollectedListener
    {
        private readonly PlayerOreStorage m_playerOreStorage;

        private List<int> m_oreCollected;

        public CollectionManager(PlayerOreStorage playerOreStorage)
        {
            m_playerOreStorage = playerOreStorage;
            Contexts.sharedInstance.unity.CreateEntity().AddOreCollectedListener(this);
        }
        
        public void OnOreCollected(GameEntity entity)
        {
            m_playerOreStorage.AddOre(entity);
        }
    }
}