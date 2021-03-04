using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager manager;

    private void Start() {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void startGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        manager.InitializeGame();
    }

    public void quitGame() {
        Application.Quit();
    }
}
