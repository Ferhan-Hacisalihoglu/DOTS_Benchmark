using UnityEngine;
using Unity.Entities;

public class BenchmarkComponentAuthoring : MonoBehaviour
{
    public GameObject[] prefabs;
    public float minThrowPeriod;
    public float maxThrowPeriod;
    public float minThrowSpeed;
    public float maxThrowSpeed;
    public int maxBalls;
}

public class BenchmarkBaker : Baker<BenchmarkComponentAuthoring>
{
    public override void Bake(BenchmarkComponentAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        
        AddComponent(entity, new BenchmarkComponent
        {
            entity1 = GetEntity(authoring.prefabs[0],TransformUsageFlags.Dynamic),
            entity2 = GetEntity(authoring.prefabs[1],TransformUsageFlags.Dynamic),
            entity3 = GetEntity(authoring.prefabs[2],TransformUsageFlags.Dynamic),
            entity4 = GetEntity(authoring.prefabs[3],TransformUsageFlags.Dynamic),
            entity5 = GetEntity(authoring.prefabs[4],TransformUsageFlags.Dynamic),
            currentThrowPeriod = 0,
            currentThrowTime = 0,
            maxBalls = authoring.maxBalls,
            maxThrowSpeed = authoring.maxThrowSpeed,
            minThrowSpeed = authoring.minThrowSpeed,
            maxThrowPeriod = authoring.maxThrowPeriod,
            minThrowPeriod = authoring.minThrowPeriod,
        });
    }
}


