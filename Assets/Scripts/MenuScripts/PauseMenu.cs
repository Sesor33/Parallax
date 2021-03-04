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

    public Animator transitionController;

    private AudioManager am; 
    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        am.Stop("BGM");
        LoadMainMenu();
    }

    public void quitGame() {
        Application.Quit();
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0)); //Main Menu
    }

    IEnumerator LoadLevel(int levelIndex) {
        transitionController.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }
}
