using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

   
    private Rigidbody2D rb;
    public float speed = 5f;
    public float dash = 5f;

    private Vector2 dir = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {   
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if(dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
