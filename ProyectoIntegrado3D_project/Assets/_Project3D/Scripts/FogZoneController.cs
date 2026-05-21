using UnityEngine;

public class FogZoneController : MonoBehaviour
{
    public Transform player;

    public float fogStart = 200f;
    public float fogEnd = 350f;

    public float fogDensity = 0.02f;

    void Update()
    {
        float z = player.position.z;

        if (z < fogStart)
        {
            //  antes de la niebla
            RenderSettings.fog = false;
            return;
        }

        if (z > fogEnd)
        {
            //  después de la niebla
            RenderSettings.fog = false;
            return;
        }

        //  dentro de la zona
        float t = Mathf.InverseLerp(fogStart, fogEnd, z);

        RenderSettings.fog = true;
        RenderSettings.fogDensity = Mathf.Lerp(0f, fogDensity, t);
    }
}