using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _bulletParticle;
    [SerializeField] private Transform _pointSpawnEffectBullet;
    [SerializeField] private float _timeBetweenShoots = 0.1f;
    [SerializeField] private int _damage = 5;

    private float _lastShootTime = 0;

    private Animator _gunAnimator;
    private const string ShootParametr = nameof(ShootParametr);

    private void Start()
    {
        _gunAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time - _lastShootTime < 0.1f) return;

        if (Input.GetMouseButton(0))
        {
            SpawnRay();
            _gunAnimator.SetTrigger(ShootParametr);
            _lastShootTime = Time.time;
        }
    }

    private void SpawnRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        SpawnEffectBullet(_bulletParticle, _pointSpawnEffectBullet);

        if (Physics.Raycast(ray, out RaycastHit hit))
            if (hit.collider.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
                enemyHealth.TakeDamage(_damage);
    }

    private void SpawnEffectBullet(GameObject effectPrefab, Transform pointSpawn)
    {
        GameObject bullet = Instantiate(effectPrefab, pointSpawn.position, pointSpawn.rotation);
        bullet.transform.SetParent(transform);
    }
}
