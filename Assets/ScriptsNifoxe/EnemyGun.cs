using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _pointSpawnBullet;

    public void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _pointSpawnBullet.position, Quaternion.identity);
    }
}
