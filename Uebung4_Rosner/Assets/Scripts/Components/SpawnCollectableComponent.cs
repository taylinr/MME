using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnCollectableComponent : IComponentData {
    public int count;
    public Entity prefab; 

   void Start() {
        EntityManager manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        manager.CreateEntity();
    }
}
