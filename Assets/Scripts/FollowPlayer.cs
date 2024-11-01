using UnityEngine;

//allows camera to follow player
public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -10);
    }
}
