using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float moveSpeed;
    private Vector2 moveInput;
    [SerializeField] public Rigidbody2D rb;
    public Transform gunArm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        MoveGunByMouse();
        

    }
    void PlayerMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rb.velocity = moveInput * moveSpeed;
        
    }
    void MoveGunByMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        //rotate gun arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x)*Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
