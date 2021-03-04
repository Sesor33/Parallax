using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [HideInInspector]
    public Slider healthBar;


    private void Start() {
        healthBar = GameObject.Find("HPBar").GetComponent<Slider>();
    }

    public void SetMaxHealth(int health) {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Start is called before the first frame update
    public void SetHealth(int health) {
        healthBar.value = health;
    }
}
