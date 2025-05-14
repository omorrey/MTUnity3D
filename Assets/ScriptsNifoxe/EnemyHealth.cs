using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _bonusGun;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float chanseSpawnBonusGun;
    [SerializeField] private float chanseHealPlayer;

    private int _maxHealth;

    private PlayerSettings playerSettings;
    private EffectHealPlayer effectHealPlayer;
    private void Start()
    {
        _maxHealth = _health;
        playerSettings = FindObjectOfType<PlayerSettings>();
        effectHealPlayer = FindObjectOfType<EffectHealPlayer>();
    }
    public void TakeDamage(int value)
    {
        _health -= value;
        UpdateHealthBar();

        if (_health < 0)
        {
            if (Random.Range(0f, 100f) <= chanseSpawnBonusGun)
                Instantiate(_bonusGun, transform.position, Quaternion.Euler(90f, 0f, 0f));
            else if (Random.Range(0f, 100f) <= chanseHealPlayer)
            {
                playerSettings.AddHealth(10);
                effectHealPlayer.ShowEffectHeal();
            }

            playerSettings.AddScore(5);
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)_health / _maxHealth;
    }
}
