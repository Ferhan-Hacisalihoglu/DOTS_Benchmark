using Unity.Entities;
using Unity.Collections;
using Unity.Physics;
using Unity.Transforms;
using Unity.Mathematics;
using System;
using Random = Unity.Mathematics.Random;

public partial class BenchmarkSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = World.Time.DeltaTime;
        Random random = new Random((uint)DateTime.Now.Ticks);
        var ecb = new EntityCommandBuffer(Allocator.TempJob);

        Entities.ForEach(
            (ref BenchmarkComponent component,in LocalTransform throwingLocation) =>
            {
                if (component.currentBall < component.maxBalls)
                {
                    if (component.currentThrowPeriod < component.currentThrowTime)
                    {
                        // time to throw a new ball
                        component.currentThrowPeriod = random.NextFloat(component.minThrowPeriod, component.maxThrowPeriod);
                        component.currentThrowTime = 0;
                        component.currentBall += 1;
                        
                        Entity newEntity;
                        switch (random.NextInt(0,5))
                        {
                            case 1:
                                newEntity = ecb.Instantiate(component.entity1);
                                break;
                            case 2:
                                newEntity = ecb.Instantiate(component.entity2);
                                break;
                            case 3:
                                newEntity = ecb.Instantiate(component.entity3);
                                break;
                            case 4:
                                newEntity = ecb.Instantiate(component.entity4);
                                break;
                            default:
                                newEntity = ecb.Instantiate(component.entity5);
                                break;
                        }

                        var transform = new LocalTransform
                        {
                            Position = throwingLocation.Position,
                            Rotation = throwingLocation.Rotation,
                            Scale = 1f
                        };

                        var velocity = new PhysicsVelocity
                        {
                            Linear = math.forward(throwingLocation.Rotation) * random.NextFloat(component.minThrowSpeed, component.maxThrowSpeed),
                            Angular = float3.zero
                        };
                        
                        ecb.AddComponent(newEntity, transform);
                        ecb.AddComponent(newEntity, velocity);
                    }
                    else
                    {
                        component.currentThrowTime += deltaTime;
                    }
                    
                    //component.currentBall++;
                }
            }
        ).Schedule();
        
        Dependency.Complete();
        
        ecb.Playback(EntityManager);
        ecb.Dispose();
    }
}
