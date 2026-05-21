using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private float timer = 0f;

    public void Shake()
    {
        timer = shakeDuration;
    }

    public Vector3 GetShakeOffset()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return Random.insideUnitSphere * shakeMagnitude;
        }

        return Vector3.zero;
    }
}
