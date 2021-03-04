using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Static ref
    public static GameManager instance;

    private AudioManager am;

    
    
    public Player player;

    void Awake() {
        

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

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
            Debug.Log("GAME OVER");
        }
    }

    public void InitializeGame() {
        player = GameObject.Find("Player").GetComponent<Player>();
        am.Play("BGM");
        
    }

    
}
