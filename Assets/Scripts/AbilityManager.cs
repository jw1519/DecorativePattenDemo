using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    Dictionary<string, PlayerAbility> activeDecorators;
    float speedBoostStartTime;
    bool speedBoostActive;

    float particlesStartTime;
    bool particlesActive;
    // Start is called before the first frame update
    void Start()
    {
        activeDecorators = new Dictionary<string, PlayerAbility>();
        speedBoostActive = false;
        particlesActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplyDecorator("SpeedBoost", new SpeedBoostDecorator(gameObject));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ApplyDecorator("Shield", new ShieldDecorator(gameObject));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RemoveDecorator("Shield");
            ApplyDecorator("Particles", new ParticleDecorator(gameObject));
        }
        // Check if 5 seconds have passed for the speed boost
        if (speedBoostActive && Time.time - speedBoostStartTime >= 5f)
        {
            RemoveDecorator("SpeedBoost");
        }
        if (particlesActive && Time.time - particlesStartTime >= 1f)
        {
            RemoveDecorator("Particles");
        }
    }
    private void ApplyDecorator(string key, PlayerAbility decorator)
    {
        if (!activeDecorators.ContainsKey(key))
        {
            decorator.Apply(gameObject);
            activeDecorators[key] = decorator;

            // Start timer for speed boost
            if (key == "SpeedBoost")
            {
                speedBoostStartTime = Time.time;
                speedBoostActive = true;
            }
            if (key == "Particles")
            {
                particlesStartTime = Time.time;
                particlesActive = true;
            }
        }
    }
    private void RemoveDecorator(string key)
    {
        if (activeDecorators.ContainsKey(key))
        {
            activeDecorators[key].Remove(gameObject); // Call the specific decorator's Remove method

            if (key == "SpeedBoost")
            {
                speedBoostActive = false; // Reset speed boost flag
            }

            activeDecorators.Remove(key); // Remove from active decorators
        }
    }
}
