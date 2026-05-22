using UnityEngine;
using UnityEngine.InputSystem; // IMPORTANTE (nuevo input system)
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{
    public GameObject container;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}