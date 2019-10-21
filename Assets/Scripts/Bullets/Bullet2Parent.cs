using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class Bullet2Parent : MonoBehaviour
{
    //ссылка на трансформы чтобы возвращать чайлдов когда сами возвращаемся в пул
    private Transform children1;
    private Transform children2;
    private Transform children3;
    private Transform children4;
    // Start is called before the first frame update
    private void OnEnable()
    {
        children1 = transform.GetChild(0);
        children2 = transform.GetChild(1);
        children3 = transform.GetChild(2);
        children4 = transform.GetChild(3);
        StartCoroutine(Destroy());
    }    

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        children1.position = transform.position;
        children2.position = transform.position;
        children3.position = transform.position;
        children4.position = transform.position;
        GetComponent<PoolObject>().Return();
    }
}
