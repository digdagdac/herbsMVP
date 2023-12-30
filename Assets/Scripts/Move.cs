using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private HerbArray targetPoint;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public float speed = 5f;
    public float dash = 5f;

    private Vector2 dir = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {   
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
 

    }
    void HandleMovementInput()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if (dir.x < 0)
        {
            sp.flipX = false;
        }
        else if (dir.x > 0)
        {
            sp.flipX = true;
        }
        if (dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Herb"))
        {
            Herbs herb = other.GetComponent<Herbs>(); 
            if (herb != null ) 
            {
                herb.isCarried= true;
            }
        }
    }
}
