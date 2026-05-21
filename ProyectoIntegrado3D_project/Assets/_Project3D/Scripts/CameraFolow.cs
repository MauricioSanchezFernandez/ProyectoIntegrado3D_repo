using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 5, -8);

    public float smoothSpeed = 5f;

    public CameraShake shake;

    void LateUpdate()
    {
        Vector3 desiredPosition =
            target.position + offset;

        //  shake añadido aquí (no rompe follow)
        Vector3 shakeOffset = shake != null ? shake.GetShakeOffset() : Vector3.zero;

        Vector3 finalPosition = desiredPosition + shakeOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            finalPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(target);
    }
}