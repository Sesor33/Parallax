using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingTextSetter : MonoBehaviour
{


    public TextMeshProUGUI destroyedRobotsText;
    // Start is called before the first frame update
    void Start()
    {
        destroyedRobotsText = gameObject.GetComponent<TextMeshProUGUI>();

        destroyedRobotsText.SetText(GameManager.enemiesKilled.ToString());

    }

}
