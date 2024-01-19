using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player Bullet")
        {
            anim.SetBool("destroy", true);
            AudioManager.instance.PLaySFX(21);
            Destroy(gameObject);
        }
    }

}
