using UnityEngine;
using System;
public class ParticleDecorator : BaseAbilityDecorator
{
    ParticleSystem particleGenerator;
    public ParticleDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player);
        particleGenerator = player.AddComponent<ParticleSystem>();
        // Configure the particle system's main module
        var mainModule = particleGenerator.main;
        mainModule.loop = false;
        mainModule.startLifetime = 0.5f;
        mainModule.startSpeed = 5.0f;
        mainModule.startSize = 0.2f;
        mainModule.startColor = Color.cyan;
        mainModule.maxParticles = 100;

        // Configure the particle system's emission module
        var emissionModule = particleGenerator.emission;
        emissionModule.rateOverTime = 0;   // Set to 0 to control emission manually
        emissionModule.burstCount = 1;
        emissionModule.SetBurst(0, new ParticleSystem.Burst(0.0f, 30));

        // Set up other modules as needed (e.g., shape, velocity, gravity)
        var shapeModule = particleGenerator.shape;
        shapeModule.shapeType = ParticleSystemShapeType.Circle;

        if (particleGenerator != null)
        {
            particleGenerator.Play();
        }
    }
    public override void Remove(GameObject player)
    {
        base.Remove(player);
        if (particleGenerator != null)
        {
            UnityEngine.Object.Destroy(particleGenerator);
        }
    }

}
