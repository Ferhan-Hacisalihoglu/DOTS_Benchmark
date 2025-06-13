using Unity.Entities;
using Unity.Mathematics;

public struct BenchmarkComponent : IComponentData
{
    public Entity entity1;
    public Entity entity2;
    public Entity entity3;
    public Entity entity4;
    public Entity entity5;
    
    public float minThrowPeriod;
    public float maxThrowPeriod;
    
    public float minThrowSpeed;
    public float maxThrowSpeed;

    public int maxBalls;
    public int currentBall;
    
    public float currentThrowPeriod;
    public float currentThrowTime;
}
