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
        _directionToPlayer = FindObjectOfType<PlayerController>().transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_directionToPlayer * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerSettings>(out PlayerSettings playerSettings))
        {
            playerSettings.Damage(5);
            if (other.TryGetComponent<EffectDamagePlayer>(out EffectDamagePlayer effectDamagePlayer))
                effectDamagePlayer.ShowEffectDamage();
        }
        Destroy(gameObject);
    }
}
