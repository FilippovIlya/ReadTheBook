using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    public GameObject child;
    void Start()
    {
        StartCoroutine(ActivateDeactivate());
    }

    IEnumerator ActivateDeactivate()
    {
        child.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        child.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ActivateDeactivate());
    }
}
