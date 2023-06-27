using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rangeAttack;
    private Vector3 moveDirection;
    [SerializeField] private Animator anim;
    public int health = 100;
    public GameObject []deatthSplatters;
    public GameObject hitEffect;

    public bool canshoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCount;
    public SpriteRenderer enemyBody;
    public float shootRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         ChasePlayer();
         ShootPlayer();

    }
    void ChasePlayer()
    {
        if (enemyBody.isVisible)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeAttack)
            {

                moveDirection = PlayerController.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection.x = 0;
                anim.SetBool("isMoving", false);
                return;

            }
            moveDirection.Normalize();
            rb.velocity = moveDirection * moveSpeed;

            if (moveDirection.x != 0)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }


            if (PlayerController.instance.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        
    }

    public void DamageEnemy(int dmg)
    {
        health -= dmg;
        Instantiate(hitEffect, transform.position, transform.rotation);
        if(health <= 0)
        {
            Destroy(gameObject);
            int selectSplatter = Random.Range(0,deatthSplatters.Length);
            int rotation = Random.Range(0, 4);
           Instantiate(deatthSplatters[selectSplatter], transform.position, Quaternion.Euler(0f, 0f,rotation*90f));
        }
    }
    void ShootPlayer()
    {
        if(enemyBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (canshoot && Vector3.Distance(transform.position, PlayerController.instance.transform.position)<shootRange)
            {
                fireCount -= Time.deltaTime;
                if (fireCount <= 0)
                {
                    fireCount = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                    AudioManager.instance.PLaySFX(13);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }
}
