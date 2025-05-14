using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    private PlayerGuns _playerGuns;
    private PlayerSettings _playerSettings;

    private void Start()
    {
        _playerGuns = GetComponent<PlayerGuns>();
        _playerSettings = GetComponent<PlayerSettings>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.GetComponent<GunBonus>())
        {
            Destroy(hit.collider.gameObject);
            _playerSettings.AddTimeBonusGun(40f);
        }
    }
}
