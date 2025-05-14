using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject _defaultGun;
    [SerializeField] private GameObject _bonusGun;

    public void SetBonusGun()
    {
        _defaultGun.SetActive(false);
        _bonusGun.SetActive(true);
    }

    public void SetDefaultGun()
    {
        _bonusGun.SetActive(false);
        _defaultGun.SetActive(true);
    }
}
