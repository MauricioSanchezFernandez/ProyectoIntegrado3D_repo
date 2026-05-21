using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject explosionFX;   // HIJO del coche
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

        //  parar movimiento del coche
        CarMovement movement = GetComponent<CarMovement>();
        if (movement != null)
            movement.enabled = false;

        //  EXPLOSIÓN (HIJA DEL COCHE)
        if (explosionFX != null)
        {
            explosionFX.SetActive(false); // reset
            explosionFX.SetActive(true);  // activar

            ParticleSystem ps = explosionFX.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Clear();
                ps.Play();
            }
        }

        //  shake cámara
        if (cameraShake != null)
        {
            cameraShake.Shake();
        }

        //  ir a Game Over
        Invoke("LoadGameOver", 1f);
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}