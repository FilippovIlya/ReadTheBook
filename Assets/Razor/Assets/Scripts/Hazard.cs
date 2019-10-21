

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Hazard : MonoBehaviour
{
    public GameObject bloodSprayPrefab;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            spriteRenderer.sprite = hitSprite;
            
            StartCoroutine(SprayBlood(3f, coll.contacts[0].point, coll.gameObject));
            coll.gameObject.GetComponent<PlayerProgress>().curLife = 0;
        }
        else
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject, 0.1f);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator SprayBlood(float delay, Vector2 position, GameObject player)
    {
        var bloodSpray = (GameObject)Instantiate(bloodSprayPrefab, position, Quaternion.identity);
        Destroy(bloodSpray, 3f);
        
        yield return new WaitForSeconds(delay);
    }
}