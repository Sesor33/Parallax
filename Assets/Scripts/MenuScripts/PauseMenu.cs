using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject quitMenu;
    public GameObject mainMenuMenu;
    public GameObject gameOverMenu;
    [HideInInspector]
    public static bool isPaused = false;

    public Animator transitionController;

    public AudioManager am;
    private GameManager gm;

    

    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.playerIsDead) {
            if (isPaused) {
                resume();
            }
            else {
                pause();
            }
        }

        if (GameManager.playerIsDead) {
            gameOverMenu.SetActive(true);
        }
         
    }

    public void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        am.Pause("BGM" + gm.getFloor());
        isPaused = true;
    }

    public void resume() {
        pauseMenu.SetActive(false);
        quitMenu.SetActive(false);
        mainMenuMenu.SetActive(false);
        Time.timeScale = 1f;
        am.Unpause("BGM" + gm.getFloor());
        isPaused = false;
    }

    public void goToMainMenu() {       
        isPaused = false;
        AudioManager.instance.Stop("BGM" + GameManager.instance.getFloor());
        Time.timeScale = 1f;
        Debug.Log("Attempting to load main menu from pausemenu");

        if (GameManager.playerIsDead) {
            SceneManager.LoadScene(0);
        }

        else {
            LoadMainMenu();
        }
        
    }

    public void quitGame() {
        Application.Quit();
    }

    public void LoadMainMenu() {
        Debug.Log("About to initialize load main menu from pause menu");
        StartCoroutine(LoadLevel(0)); //Main Menu
    }

    IEnumerator LoadLevel(int levelIndex) {
        Debug.Log("Made it into LoadLevel");
        transitionController.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }


}
