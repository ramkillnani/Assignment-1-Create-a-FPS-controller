using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactetController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private float verticalDirection;
    private float horizontalDirection;
    public Animator anim;
    

    void Update()
    {if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Run", true);
        }
    else
        {
            anim.SetBool("Run", false);
        }

        verticalDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        horizontalDirection = Input.GetAxis("Horizontal") * moveSpeed/3 * Time.deltaTime;
        transform.Translate(horizontalDirection, 0, verticalDirection);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetBool("Jump", true);
            var rigid = this.gameObject.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                rigid.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            }
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        anim.GetComponent<Animator>();
    }
}
