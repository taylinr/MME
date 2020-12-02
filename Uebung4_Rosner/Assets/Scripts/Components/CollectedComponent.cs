using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct CollectedComponent : IComponentData {
    public bool isCollected;

   void Start() {
        EntityManager manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        manager.CreateEntity();


    }
}
