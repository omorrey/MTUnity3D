using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image gunBonusBar;

    private PlayerGuns playerGuns;

    private int score;
    private float gunBonusTime;
    private int maxHealth;
    void Start()
    {
        maxHealth = health;
        playerGuns = FindObjectOfType<PlayerGuns>();
    }

    void Update()
    {
        gunBonusTime -= Time.deltaTime;
        UpdateBonusGunBar();

        if (gunBonusTime <= 0)
        {
            playerGuns.SetDefaultGun();
            gunBonusTime = 0;
        }
        else
        {
            playerGuns.SetBonusGun();
        }
    }

    public void AddHealth(int value)
    {
        health += value;

        if (health > maxHealth)
            health = maxHealth;

        UpdateHealthBar();
    }

    public void AddTimeBonusGun(float value)
    {
        gunBonusTime += value;
        if (gunBonusTime > 100)
            gunBonusTime = 0;
        UpdateBonusGunBar();
    }
    public void AddScore(int value)
    {
        if (value <= 0)
            return;
        score += value;

        UpdateScoreText();
    }

    public void Damage(int value)
    {
        health -= value;
        UpdateHealthBar();

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateBonusGunBar()
    {
        gunBonusBar.fillAmount = gunBonusTime / 100f;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)health / maxHealth;
    }
}
