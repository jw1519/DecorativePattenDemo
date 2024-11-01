using UnityEngine;

public abstract class BaseAbilityDecorator : PlayerAbility
{
    protected GameObject player;

    // Constructor for initialising the player object
    public BaseAbilityDecorator(GameObject player)
    {
        this.player = player;
    }
    // Default apply and remove functionality with logging
    public virtual void Apply(GameObject player)
    {
        Debug.Log($"{GetType().Name} applied to {player.name}");
    }

    public virtual void Remove(GameObject player)
    {
        Debug.Log($"{GetType().Name} removed from {player.name}");
    }
}
