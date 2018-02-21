using System.Collections.Generic;
using Mine.ECS.Gameplay.Mining.Ore;
using UnityEngine;

namespace Mine.unity.Managers
{
    public class PlayerOreStorage
    {

        private List<int> m_oreCollected;

        public PlayerOreStorage()
        {
            m_oreCollected = new List<int>();
        }

        public int Money { get; set; }

        public void AddOre(GameEntity ore)
        {
            if (m_oreCollected.IndexOf(ore.id.value) == -1)
            {
                m_oreCollected.Add(ore.id.value);
            }

            var value = 5; //ore.oreValue.value;
            var weight = 2; //ore.weight.value;
            OreFactory.CreateCollectedOrePiece("Copper", value, weight);
        }

        public void RemoveOre(GameEntity ore)
        {
           m_oreCollected.Remove(ore.id.value);
        }

        public List<int> GetCollectedOre()
        {
            return m_oreCollected;
        }


        public void SellOre()
        {
            Money += m_oreCollected.Count * 12;
            m_oreCollected = new List<int>();
        }
     
    }
}