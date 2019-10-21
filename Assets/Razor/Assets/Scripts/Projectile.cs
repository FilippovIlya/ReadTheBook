using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
