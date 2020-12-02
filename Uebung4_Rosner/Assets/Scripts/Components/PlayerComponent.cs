using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerComponent : IComponentData {
    public float speed;
    public float rotationAngle; 

   void Start() {
        EntityManager manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        manager.CreateEntity();
    }
}
