using System.Collections;
using Client;
using Leopotam.Ecs;
using UnityEngine;

[DefaultExecutionOrder(-111)]
public abstract class Actor : MonoBehaviour
{
    public EcsEntity entity;

    protected EcsWorld world;

    protected virtual void Awake()
    {
        if (EcsStartup.World == null)
        {
            EcsStartup.OnWorldCreated += () => Init(EcsStartup.World);
        }
        else
        {
            Init(EcsStartup.World);
        }
    }

    protected virtual void OnDestroy()
    {
        if (entity.IsAlive())
        {
            entity.Destroy();
        }
    }

    private void Init(EcsWorld aWorld)
    {
        if (world != null)
        {
            return;
        }

        world = aWorld;
        entity = world.NewEntity();
        AddBaseComponent();
        ExpandEntity();
    }

    public abstract void ExpandEntity();

    public void SelfDestroy(float delay = 0f)
    {
        StartCoroutine(SelfDestroyCoroutine(delay));
    }

    public IEnumerator SelfDestroyCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        if (entity.IsAlive())
        {
            entity.Destroy();
        }
    }

    private void AddBaseComponent()
    {
        ref var baseComponent = ref entity.Get<BaseComponent>();
        baseComponent.gameObject = gameObject;
        baseComponent.transform = transform;
        baseComponent.actor = this;
    }
}