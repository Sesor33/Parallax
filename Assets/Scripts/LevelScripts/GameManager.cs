using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Static ref
    public static GameManager instance;

    public AudioManager am;

    public Animator transitionController;

    public Player player;

    public static bool playerIsDead;
    public static int floor;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

       
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1) {
            InitializeGame();
        }

        else {
            am.Play("BGM" + floor);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0) {
            Debug.Log("GAME OVER");
            playerIsDead = true;
        }
    }

    public void InitializeGame() {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerIsDead = false;
        floor = 1;
        Debug.Log("Attempting to play BGM1");
        am.Play("BGM1");
        
    }

    public void LoadNextLevel() {
        am.Stop("BGM" + floor);
        floor++;
        Debug.Log("Loading next level: " + SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu() {
        Debug.Log("Attempting to load main menu");
        StartCoroutine(LoadLevel(0)); //Main Menu
    }

    IEnumerator LoadLevel(int levelIndex) {
        transitionController.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }


}
