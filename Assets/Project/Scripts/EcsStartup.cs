using System;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace Client
{
    internal sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public static event Action OnWorldCreated;


        #region Public static

        public static EcsWorld World;
        public static EcsStartup Instance { get; private set; }

        #endregion Public static

        private void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            World = _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
            EcsSystemsObserver.Create(_systems);
#endif
            _systems
                .Add(new InputSystem())
                .Add(new PlayerControlSystem())
                .Add(new MoveSystem())
                .OneFrame<MouseDownEvent>()
                .Init();

            OnWorldCreated?.Invoke();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}