using UnityEngine;
using UnityEditor;
using Unity.Collections;
using System.Collections.Generic;
public class ParticleDecorator : BaseAbilityDecorator
{
    ParticleSystem particleGenerator;
    public ParticleDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player);
        particleGenerator = player.AddComponent<ParticleSystem>();
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
            
        }
    }

}
