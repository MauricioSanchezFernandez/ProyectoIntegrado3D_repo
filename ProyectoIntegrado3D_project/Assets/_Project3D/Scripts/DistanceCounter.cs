using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
   public Transform player;
    public TextMeshProUGUI distanceText;

    private float startZ;

    public int CurrentMeters { get; private set; }

    private void Start()
    {
        startZ = player.position.z;
    }

    private void Update()
    {
        float distance = player.position.z - startZ;

        CurrentMeters = Mathf.FloorToInt(distance);

        distanceText.text = CurrentMeters + " m";
    }

    // Guardar puntuación
    public void SaveScore()
    {
        PlayerPrefs.SetInt("LastScore", CurrentMeters);
        PlayerPrefs.Save();
    }
    
}