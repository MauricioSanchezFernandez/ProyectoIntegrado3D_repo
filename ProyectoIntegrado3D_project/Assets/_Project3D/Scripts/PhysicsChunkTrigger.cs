using UnityEngine;

public class PhysicsChunkTrigger : MonoBehaviour
{
    public Rigidbody[] barrels;

    public float forwardForce = 5f;
    public float torqueForce = 10f;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            ActivateBarrels();
        }
    }

     void ActivateBarrels()
    {
     foreach (Rigidbody rb in barrels)
     {
          rb.isKinematic = false;
          rb.useGravity = true;

           rb.linearVelocity = Vector3.zero;
          rb.angularVelocity = Vector3.zero;

          //  fuerza hacia un lado + un poco hacia delante
           Vector3 forceDir = (Vector3.right * Random.Range(-1f, 1f)) + (Vector3.forward * 0.5f);

           rb.AddForce(forceDir.normalized * forwardForce, ForceMode.Impulse);

           //  esto es CLAVE para que RUEDE
           rb.AddTorque(Vector3.right * torqueForce, ForceMode.Impulse);
     }
    }
}
