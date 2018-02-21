using Entitas;
using Libraries.btcp.ECS.src.Core;
using Mine.ECS;
using Mine.ECS.Factories;
using Mine.ECS.Gameplay.Mining.Ore;
using Mine.unity.Rooms;
using UnityEngine;

namespace Mine.unity
{
    public class ECSController : MonoBehaviour
    {
        private Contexts m_contexts;
        private Systems m_systems;

       
        private Room m_roomTest;

        private void Awake()
        {
            m_contexts = Contexts.sharedInstance;

            foreach (var ctx in m_contexts.allContexts)
            {
                ctx.OnEntityCreated += AddEntityId;
            }

            m_systems = CreateSystems(m_contexts);
            m_systems.Initialize();

            m_roomTest = RoomManager.CreateRoom();

        }

        private void AddEntityId(IContext context, IEntity entity)
        {
            var e = entity as GameEntity;
            if (e != null)
                e.AddId(e.creationIndex);
        }

        private void Update()
        {
            m_systems.Execute();
            m_systems.Cleanup();
        }

        private void OnDestroy()
        {
            m_systems.TearDown();
        }

        private Systems CreateSystems(Contexts contexts)
        {
            //TODO : Organise Systems into Main Features
            // InitSystems, InputSystems, UpdateSystems, EventSystems, CleanupSystems
            //TODO : Putting Core Systems first will cause Goap Agent to not recieve AttackComplete since it's cleaned up
            return new Feature("Main Systems")
                    .Add(new MineSystems(contexts))
                    .Add(new CoreSystems(contexts))
                ;
        }
    }
}