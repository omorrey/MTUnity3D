using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelDamage;
    
    public void ShowEffectDamage()
    {
        StartCoroutine(EffectDamage());
    }
    private IEnumerator EffectDamage()
    {
        _panelDamage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _panelDamage.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _panelDamage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _panelDamage.SetActive(false);
        yield break;
    }
}
