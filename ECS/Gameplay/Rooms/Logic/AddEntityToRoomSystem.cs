using System.Collections.Generic;
using Entitas;
using Mine.unity.Rooms;

public class AddEntityToRoomSystem : ReactiveSystem<GameEntity>
{
    private Contexts m_contexts;

    public AddEntityToRoomSystem (Contexts contexts) : base(contexts.game)
    {
        m_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.RoomChild);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasRoomChild;    
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            RoomManager.AddEntityToRoom(e, e.roomChild.id);
        }
    }
}
