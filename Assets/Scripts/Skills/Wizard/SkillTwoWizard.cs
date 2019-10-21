using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class SkillTwoWizard : MonoBehaviour
{
    private void OnEnable()
    {
        
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        
        GetComponent<PoolObject>().Return();
    }
}
