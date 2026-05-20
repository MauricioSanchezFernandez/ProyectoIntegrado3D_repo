using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceText;

    private float startZ;

    private void Start()
    {
        startZ = player.position.z;
    }

    private void Update()
    {
        float distance = player.position.z - startZ;

        int meters = Mathf.FloorToInt(distance);

        distanceText.text = meters + " m";
    }
}