using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _bonusGun;
    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health < 0)
        {
            Instantiate(_bonusGun, transform.position, Quaternion.Euler(90f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}
