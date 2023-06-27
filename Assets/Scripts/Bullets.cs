using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 7.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletEffect;
    [SerializeField] private float bulletRange;
    public int damageToGive = 50;


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
        else if(other.tag == "Room")
        {
            return;
        }else
        {
            Instantiate(bulletEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            AudioManager.instance.PLaySFX(4);
        }
        if (other.tag == "Enemy"){
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
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
