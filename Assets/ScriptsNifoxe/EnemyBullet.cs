using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _directionToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _directionToPlayer = transform.position - FindObjectOfType<PlayerController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_directionToPlayer * speed * Time.deltaTime);
    }
}
