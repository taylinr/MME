using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnCollectableSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate(){
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }
    protected override void OnUpdate(){

        var seed = (uint) UnityEngine.Random.Range(0, 23456789);
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Entity entity, int entityInQueryIndex, in SpawnCollectableComponent spawnComponent) => {
                var random = new Unity.Mathematics.Random(seed);
                for (var x = 0; x < spawnComponent.count; x++){
                    Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, spawnComponent.prefab);

                    float3 position = new float3(random.NextFloat(-10, 10), 0, random.NextFloat(-10, 10));
                    commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Translation { Value = position });
                }

                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel();
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);

    }
}
