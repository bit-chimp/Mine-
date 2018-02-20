using Entitas;

using Libraries.btcp.ECS.src.Core;
using Mine.ECS;
using Mine.ECS.Factories;
using Mine.ECS.Gameplay.Mining.Ore;
using UnityEngine;

namespace Mine.unity
{
    public class GameController : MonoBehaviour
    {
        private Contexts m_contexts;
        private Systems m_systems;

        public int miners = 0;
        public int spiders = 3;

        private void Awake()
        {
            m_contexts = Contexts.sharedInstance;

            foreach (var ctx in m_contexts.allContexts)
            {
                ctx.OnEntityCreated += AddEntityId;
            }

            m_systems = CreateSystems(m_contexts);
            m_systems.Initialize();

            for (var i = 0; i < miners; i++)
            {
                MinerFactory.CreateMiner(m_contexts, new Vector2(Random.Range(-3f, 3f), 0));

            }
            
            for (var i = 0; i < spiders; i++)
            {
                EnemyFactory.CreateEnemy(m_contexts, new Vector2(Random.Range(-15f, -5f), 0));
            }

            OreFactory.CreateOreVein(m_contexts.game, new Vector2(5, .5f));
            DefenseFactory.CreateTurret(m_contexts, new Vector2(0, 3));

        }

        private void AddEntityId(IContext context, IEntity entity)
        {
            var e = entity as GameEntity;
            if(e != null)
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