using UnityEngine;

public class SpeedBoostDecorator : BaseAbilityDecorator
{
    private float boostMultiplier = 2f;
    private float originalSpeed;

    public SpeedBoostDecorator(GameObject player) : base(player) { }

    public override void Apply(GameObject player)
    {
        base.Apply(player); // Calls the base class to log application
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            originalSpeed = playerMovement.speed;
            playerMovement.speed *= boostMultiplier;
        }
    }

    public override void Remove(GameObject player)
    {
        base.Remove(player); // Calls the base class to log removal
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.speed = originalSpeed;
        }
    }
}
