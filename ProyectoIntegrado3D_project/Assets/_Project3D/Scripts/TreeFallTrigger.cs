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

            // 💥 caída hacia la carretera con variación
            Vector3 forceDir = (Vector3.right * Random.Range(-1f, 1f)) + Vector3.down * 0.5f;

            treeRb.AddForce(forceDir.normalized * fallForce, ForceMode.Impulse);

            // 🌪️ giro natural
            treeRb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);
        }
    }
}