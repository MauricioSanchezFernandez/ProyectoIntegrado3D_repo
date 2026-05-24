using UnityEngine;

public class TreeFallTrigger : MonoBehaviour
{
    public Rigidbody[] trees;

    public float fallForce = 5f;
    public float torqueForce = 10f;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;
            FallTrees();
        }
    }

   void FallTrees()
{
    foreach (Rigidbody treeRb in trees)
    {
        if (treeRb == null) continue;

        treeRb.isKinematic = false;
        treeRb.useGravity = true;

        // reset físico
        treeRb.linearVelocity = Vector3.zero;
        treeRb.angularVelocity = Vector3.zero;

        //  empujar SIEMPRE hacia carretera
        treeRb.AddForce(Vector3.right * fallForce, ForceMode.Impulse);

        //  rotación CONTROLADA
        treeRb.AddTorque(Vector3.forward * torqueForce, ForceMode.Impulse);
    }
}
}