using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.GetComponent<GunBonus>())
        {
            GetComponent<PlayerGuns>()._defaultGun.SetActive(false);
            GetComponent<PlayerGuns>()._bonusGun.SetActive(true);
            Destroy(hit.collider.gameObject);
        }
    }
}
