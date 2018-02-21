using UnityEngine;

namespace Mine.unity.Rooms
{
    public class RoomManager
    {

        private static Room m_room;
        
        public static Room CreateRoom()
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Rooms/Room_Test"));
            m_room = new Room(go);
            return m_room;
        }

        public static void AddEntityToRoom(GameEntity e, int roomId)
        {
            m_room.AddToRoom(e);
        }
    }
}