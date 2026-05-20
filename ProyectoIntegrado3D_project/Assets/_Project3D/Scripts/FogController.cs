using UnityEngine;

public class FogController : MonoBehaviour
{
    public Transform player;

    public float startFog = 200f;
    public float endFog = 350f;

    public float maxDensity = 0.02f;

    void Update()
    {
        float distance = player.position.z;

        float t = Mathf.InverseLerp(startFog, endFog, distance);

        if (distance < startFog || distance > endFog)
        {
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.fog = true;
            RenderSettings.fogDensity = Mathf.Lerp(0f, maxDensity, t);
        }
    }
}
