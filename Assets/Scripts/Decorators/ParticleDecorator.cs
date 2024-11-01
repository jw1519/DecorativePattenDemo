using UnityEngine;

public class ParticleDecorator : BaseAbilityDecorator
{
    ParticleSystem paticleGenerator;
    public ParticleDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player);
        paticleGenerator = player.GetComponentInChildren<ParticleSystem>();
        if (paticleGenerator != null)
        {
            paticleGenerator.Play();
        }

    }
    public override void Remove(GameObject player)
    {
        base.Remove(player);
        paticleGenerator = player.GetComponentInChildren<ParticleSystem>();
        if (paticleGenerator != null)
        {
            paticleGenerator.Stop();
        }
    }

}
