using System.Collections;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject itemToShootPrefab;

    [SerializeField]
    private float shootStartDelay = 0.1f;

    [SerializeField]
    private float shootInterval = 2f;

    [SerializeField]
    private float destroyItemDelay = 3f;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(ShootObject(shootInterval));
    }

    private IEnumerator ShootObject(float delay)
    {
        yield return new WaitForSeconds(delay + shootStartDelay);
        shootStartDelay = 0f;
        var item = (GameObject) Instantiate(itemToShootPrefab, transform.position, transform.rotation);
        Destroy(item, destroyItemDelay);
        StartCoroutine(ShootObject(shootInterval));
    }

}
