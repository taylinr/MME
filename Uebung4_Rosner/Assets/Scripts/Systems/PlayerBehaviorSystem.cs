using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerBehaviorSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate(){
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }
    protected override void OnUpdate(){

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((ref Rotation rotation, ref Translation translation, in PlayerComponent playerComponent) => {
                //Rotation
                float rotationAngle = playerComponent.rotationAngle + horizontal;
                float3 targetDirectionRotation = new float3 (math.sin(rotationAngle) , 0, math.cos(rotationAngle));
                rotation.Value = quaternion.LookRotationSafe(targetDirectionRotation, Vector3.up);

                //Translation
                float translationSteps = playerComponent.speed * vertical;
                float3 targetDirectionTranslation = new float3 (0, 0, translationSteps);
                translation.Value = targetDirectionTranslation;
            }).ScheduleParallel();
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);

    }
}
