using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _bonusGun;
    [SerializeField] private Image _healthBar;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
    }
    public void TakeDamage(int value)
    {
        _health -= value;
        UpdateHealthBar();

        if (_health < 0)
        {
            Instantiate(_bonusGun, transform.position, Quaternion.Euler(90f, 0f, 0f));
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)_health / _maxHealth;
    }
}
