using UnityEngine;
using UnityEngine.SceneManagement;

public class CarDeath : MonoBehaviour
{
    public GameObject explosionFX;
    public CameraShake cameraShake;

    public string gameOverSceneName = "GameOver";

    private bool dead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;

        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;

        // Guardar puntuación
        DistanceCounter distanceCounter = FindObjectOfType<DistanceCounter>();

        if (distanceCounter != null)
        {
            distanceCounter.SaveScore();
        }

        // parar movimiento del coche
        CarMovement movement = GetComponent<CarMovement>();

        if (movement != null)
            movement.enabled = false;

        // explosión
        if (explosionFX != null)
        {
            explosionFX.SetActive(false);
            explosionFX.SetActive(true);

            ParticleSystem ps = explosionFX.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Clear();
                ps.Play();
            }
        }

        // shake cámara
        if (cameraShake != null)
        {
            cameraShake.Shake();
        }

        // ir a Game Over
        Invoke("LoadGameOver", 1f);
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}