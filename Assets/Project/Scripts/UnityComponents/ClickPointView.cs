using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Client;

public class ClickPointView : Actor
{
    public override void ExpandEntity() { ref var clickPointViewComponent = ref entity.Get<ClickPointViewComponent>(); }
}
