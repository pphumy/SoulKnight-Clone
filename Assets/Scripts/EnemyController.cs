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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }
    void ChasePlayer()
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
