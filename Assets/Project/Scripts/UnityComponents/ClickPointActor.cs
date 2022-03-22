using Leopotam.Ecs;

public class ClickPointActor : Actor
{
    public override void ExpandEntity()
    {
        entity.Get<ClickPointComponent>();
    }
}