using UnityEngine;

// creates a visible shield around the player by adding a sphere around the player and applying a semi-transparent material to it
public class ShieldDecorator : BaseAbilityDecorator
{
    private GameObject shieldObject;

    public ShieldDecorator(GameObject player) : base(player) { }
    public override void Apply(GameObject player)
    {
        base.Apply(player); // Log application
        if (shieldObject == null)
        {
            // Create a sphere as the shield visual
            shieldObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            shieldObject.transform.SetParent(player.transform);
            shieldObject.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f);
            shieldObject.transform.localPosition = Vector3.zero;

            // Set material for transparency
            Material shieldMaterial = new Material(Shader.Find("Standard"));
            shieldMaterial.color = new Color(0f, 1f, 1f, 0.5f); // Cyan with 50% transparency
            shieldMaterial.SetFloat("_Mode", 3); // Set rendering mode to Transparent
            shieldMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            shieldMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            shieldMaterial.SetInt("_ZWrite", 0);
            shieldMaterial.DisableKeyword("_ALPHATEST_ON");
            shieldMaterial.EnableKeyword("_ALPHABLEND_ON");
            shieldMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            shieldMaterial.renderQueue = 3000;

            // Apply the material to the shield object
            shieldObject.GetComponent<Renderer>().material = shieldMaterial;
        }
    }

    public override void Remove(GameObject player)
    {
        base.Remove(player); // log removal
        if (shieldObject != null)
        {
            GameObject.Destroy(shieldObject);
            shieldObject = null;
        }
    }
}
