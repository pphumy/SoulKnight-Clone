using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    // Start is called before the first frame update
    [SerializeField] public float moveSpeed;
    private Vector2 moveInput;
    [SerializeField] public Rigidbody2D rb;
    public Transform gunArm;
    public Animator anim;

    [SerializeField] private float speedShots;
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform firePoint;
    private float shotDelay;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIController.instance.isPause)
        {
            PlayerMovement();
            MoveGunByMouse();
            FireGun();
        }
        



    }
    void PlayerMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
        if(moveInput.x != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
    }
    void MoveGunByMouse()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector3 mousePos = Input.mousePosition;


        //rotate gun arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x)*Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0f, 0f, angle);

        //Switching directions of the player
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);

        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            gunArm.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void FireGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullets, firePoint.position, firePoint.rotation);
            shotDelay = speedShots;
            AudioManager.instance.PLaySFX(12);
        }
        if (Input.GetMouseButtonDown(0))
        {
            shotDelay -= Time.deltaTime;
            if(shotDelay <= 0)
            {
                Instantiate(bullets, firePoint.position, firePoint.rotation);
                AudioManager.instance.PLaySFX(12);
            }
            shotDelay = speedShots;
        }

    }



}
