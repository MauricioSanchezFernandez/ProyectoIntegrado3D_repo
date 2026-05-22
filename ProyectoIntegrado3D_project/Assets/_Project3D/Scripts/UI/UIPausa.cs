using UnityEngine;
using UnityEngine.InputSystem; // IMPORTANTE (nuevo input system)
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{
    public GameObject panelIntro;

    void Start()
    {
        Time.timeScale = 0f; // pausa el juego
        panelIntro.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           panelIntro.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnContinue()
    {
        panelIntro.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}