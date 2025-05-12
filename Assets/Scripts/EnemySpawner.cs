using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
 [SerializeField] Transform[] spawnTargets;
 [SerializeField] GameObject enemyPrefab;

 [SerializeField] private float spawnInterval = 20f;

 private float intervalScaler = 1;
 
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    { 
        while (true)
        {
            int randomIndexPoint = Random.Range(0, spawnTargets.Length);
            Vector3 targetPos = spawnTargets[randomIndexPoint].position;
            Instantiate(enemyPrefab, targetPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval * intervalScaler);

            if(spawnInterval * intervalScaler >= 2f)
            {
                intervalScaler -= 0.015f;
            }

            Debug.Log(spawnInterval * intervalScaler);
        }
    }

}
