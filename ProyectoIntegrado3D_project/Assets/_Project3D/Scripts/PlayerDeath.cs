using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject explosionFX;
    public CameraShake cameraShake;

    public AudioSource explosionSound;

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

        //  parar coche
        CarMovement movement = GetComponent<CarMovement>();
        if (movement != null)
            movement.enabled = false;

        //  explosión
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

        //  sonido explosión
        if (explosionSound != null)
        {
            explosionSound.Play();
        }

        //  shake cámara
        if (cameraShake != null)
        {
            cameraShake.Shake();
        }

        //  game over
        Invoke("LoadGameOver", 1f);
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}