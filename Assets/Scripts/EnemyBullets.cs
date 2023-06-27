using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{



    public float speed;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        shootBullets();
    }
    void shootBullets()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag =="Room")
        {
            return;
        }
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
        Destroy(gameObject);
        AudioManager.instance.PLaySFX(4);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

