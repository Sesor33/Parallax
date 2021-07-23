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
    public static bool isDebug;

    public static int playerDamage;

    public static int enemiesKilled;

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

        //DEBUG LINE, SET THIS TO FALSE TO DISABLE ALL DEBUG STATEMENTS
        isDebug = false;

    }

    // called first
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (isDebug) {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }       

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            Destroy(gameObject);
        }
        else if (SceneManager.GetActiveScene().buildIndex > 1) {
            RepopulateAfterLevelChange();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1) {
            InitializeGame();
        }     

    }


    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0) {
            if (isDebug) {
                Debug.Log("GAME OVER");
            }
            
            playerIsDead = true;
        }
    }

    public void InitializeGame() {       
        floor = 1;

        player = GameObject.Find("Player").GetComponent<Player>();

        playerIsDead = false;

        playerDamage = 1;

        enemiesKilled = 0;

        if (isDebug) {
            Debug.Log("Attempting to play BGM1");
        }
       
        am.Play("BGM1");
        
    }

    public void RepopulateAfterLevelChange() {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerIsDead = false;
        transitionController = GameObject.Find("Fade").GetComponent<Animator>();
        am.Play("BGM" + floor);
    }

    public void LoadNextLevel() {
        am.Stop("BGM" + floor);
        floor++;

        if (isDebug) {
            Debug.Log("Loading next level: " + SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu() {
        if (isDebug) {
            Debug.Log("Attempting to load main menu");
        }
        
        StartCoroutine(LoadLevel(0)); //Main Menu
    }

    public static void incrementEnemiesKilled() {
        enemiesKilled++;
    }

    public int getFloor() {
        return floor;
    }

    public void stopCurrentFloorSong() {
        am.Stop("BGM" + floor);
    }

    IEnumerator LoadLevel(int levelIndex) {
        transitionController.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }


}
