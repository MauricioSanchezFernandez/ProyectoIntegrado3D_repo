using UnityEngine;

public class FogFollow : MonoBehaviour
{
    public Transform player;
    public float offsetZ = 50f;

    void Update()
    {
        Vector3 pos = player.position;
        pos.z += offsetZ;

        transform.position = pos;
    }
}
