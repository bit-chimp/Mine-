using UnityEngine;

namespace Mine.unity.Rooms
{
    public class Room
    {

        private GameObject m_roomGameObject;
        private GameEntity m_entityContainer;

        public Room(GameObject room)
        {
            m_roomGameObject = room;
            m_entityContainer = Contexts.sharedInstance.game.CreateEntity();
            m_entityContainer.AddGameObject(m_roomGameObject.transform.Find("Entities").gameObject);
            m_entityContainer.isRoom = true;
        }
        
        
        public void AddToRoom(GameEntity e)
        {
        }

        public GameEntity GetEntity()
        {
            return m_entityContainer;
        }
    }
}