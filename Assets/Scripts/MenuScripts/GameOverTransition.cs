using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverTransition : MonoBehaviour
{
    public Animator transitionController;

    public AudioManager am;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void LoadMainMenu() {      
        //Debug.Log("About to initialize load main menu from pause menu");
        //StartCoroutine(LoadLevel(0)); //Main Menu
        GameManager.instance.stopCurrentFloorSong();
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int levelIndex) {
        Debug.Log("Made it into LoadLevel");
        transitionController.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelIndex);
    }
}
