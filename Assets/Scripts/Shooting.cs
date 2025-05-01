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
    [SerializeField] private Camera _mainCamera;

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

        if(Input.GetMouseButton(0))
        {
            SpawnRay();
            _gunAnimator.SetTrigger(ShootParametr);
            _lastShootTime = Time.time;
        }
    }

    private void SpawnRay()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        SpawnEffectBullet(_bulletParticle, _pointSpawnEffectBullet);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
        }
    }

    private void SpawnEffectBullet(GameObject effectPrefab, Transform pointSpawn)
    {
        Instantiate(effectPrefab, pointSpawn.position, pointSpawn.rotation);
    }
}
