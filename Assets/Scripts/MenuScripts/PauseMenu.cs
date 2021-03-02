using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject quitMenu;
    public GameObject mainMenuMenu;
    [HideInInspector]
    public static bool isPaused = false;

    public AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                resume();
            }
            else {
                pause();
            }
        }
         
    }

    public void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        am.Pause("BGM");
        isPaused = true;
    }

    public void resume() {
        pauseMenu.SetActive(false);
        quitMenu.SetActive(false);
        mainMenuMenu.SetActive(false);
        Time.timeScale = 1f;
        am.Unpause("BGM");
        isPaused = false;
    }

    public void goToMainMenu() {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame() {
        Application.Quit();
    }
}
