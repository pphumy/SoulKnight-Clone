using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 7.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletEffect;
    [SerializeField] private float bulletRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullets();
        DestroyBullet();
    }
    void ShootBullets()
    {
        rb.velocity = transform.right * bulletSpeed;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name== "Player"){
            return;
         }
        else
        {
            Instantiate(bulletEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Orc")
        {
            Destroy(other.gameObject);
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void DestroyBullet()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > bulletRange)
        {
            Destroy(gameObject);
        }
    }
}
