using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite[] healthImage;


    void Start()
    {
        healthBar.sprite = healthImage[health];

    }

    void Update()
    {

    
        
    }

    public void Damage()
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        healthBar.sprite = healthImage[health];
    }

}
