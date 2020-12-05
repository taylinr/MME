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
        float deltaTime = (float)Time.DeltaTime;

        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((ref Rotation rotation, ref Translation translation, ref PlayerComponent playerComponent) => {
                
                //Rotation
                playerComponent.rotationAngle += horizontal * deltaTime;
                float rotationAngle = playerComponent.rotationAngle;
                float3 targetDirectionRotation = new float3 (math.sin(rotationAngle), 0, math.cos(rotationAngle));
                rotation.Value = quaternion.LookRotationSafe(targetDirectionRotation, Vector3.up);


                //Translation
                float3 targetDirectionTranslation = targetDirectionRotation * playerComponent.speed * vertical;
                translation.Value += targetDirectionTranslation;
            }).ScheduleParallel();
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);

    }
}
