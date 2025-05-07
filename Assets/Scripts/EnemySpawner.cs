using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
 [SerializeField] Transform[] spawnTargets;
 [SerializeField] GameObject enemyPrefab;
 
    private void Start()
    {
        StartCoroutine (Spawn());
    }

    private IEnumerator Spawn()
    { 
        while (true){
        int randomIndexPoint = Random.Range(0, spawnTargets.Length);
        Vector3 targetPos = spawnTargets[randomIndexPoint].position;
        Instantiate(enemyPrefab, targetPos, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        }
    }

}
