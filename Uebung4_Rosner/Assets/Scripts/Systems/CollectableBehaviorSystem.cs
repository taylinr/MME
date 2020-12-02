using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class CollectableBehaviorSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float elapsedTime = (float)Time.ElapsedTime;
        Entities.ForEach((ref Rotation rotation) =>
        {
            rotation.Value = Quaternion.Euler(0, Mathf.Sin(elapsedTime) * 360, 0);;
        }).ScheduleParallel();
    }

}
