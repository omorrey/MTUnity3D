using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelHeal;

    public void ShowEffectHeal()
    {
        StartCoroutine(EffectHeal());
    }
    private IEnumerator EffectHeal()
    {
        _panelHeal.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _panelHeal.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _panelHeal.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _panelHeal.SetActive(false);
        yield break;
    }
}
