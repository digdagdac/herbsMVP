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

    public Herbs carriedHerb;

    private Vector2 dir = Vector2.zero;

    public int curindex = -1;
    Inventory inventory;
    public Herbs[] herbs;
    private Vector2 ReSpown;
    private int spownNum=1;

    public GameObject slotitem;

    private PlayerArray playerHerbArray;

    public static bool LeftClick = false;
    void Start()
    {   
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();        
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        playerHerbArray =GetComponent<PlayerArray>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        if (curindex == 3)
        {
            curindex = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (carriedHerb !=null)
            {

                //    carriedHerb.isMoving = false;
                //    //carriedHerb.PickUp(); 여기에 함수넣어서 처리하기
                LeftClick= true;
                playerHerbArray.playerAddHerb(carriedHerb);
                curindex++;

            }
            
        }
        if (Input.GetMouseButtonDown(1))
        {
           
            curindex--;
           
            playerHerbArray.RemoveHerbs(curindex, spownNum);

            //string HerbName = inventory.slots[curindex].slotObj.transform.GetChild(0).name;
            //Debug.Log(HerbName);
            //ReSpown = new Vector2(this.transform.position.x + spownNum, this.transform.position.y);//바라보는방향에따라 이거 나중에해야지...

            //switch (HerbName)
            //{
            //    case "Herb1Img(Clone)":
            //        Instantiate(herbs[0], ReSpown, Quaternion.identity);
            //        break;
            //    case "Herb2Img(Clone)":
            //        Instantiate(herbs[1], ReSpown, Quaternion.identity);
            //        break;
            //    case "Herb3Img(Clone)":
            //        Instantiate(herbs[2], ReSpown, Quaternion.identity);
            //        break;
            //    case "Herb4Img(Clone)":
            //        Instantiate(herbs[3], ReSpown, Quaternion.identity);
            //        break;
            //    case "Herb5Img(Clone)":
            //        Instantiate(herbs[4], ReSpown, Quaternion.identity);
            //        break;
            //    default:
            //        break;
            //}
            //Destroy(inventory.slots[curindex].slotObj.transform.GetChild(0).gameObject);
            //curindex--;
            //if (curindex >= inventory.slots.Count)
            //{
            //    curindex = 0;
            //}



        }


    }
    void HandleMovementInput()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        if (dir.x < 0)
        {
            sp.flipX = false;
            spownNum = -1;
        }
        else if (dir.x > 0)
        {
            sp.flipX = true;
            spownNum = +1;
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
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            Herbs collidedHerb = collision.gameObject.GetComponent<Herbs>();
            if (collidedHerb != null)
            {
                carriedHerb = collidedHerb;
                SpriteOutline spriteOutline = carriedHerb.GetComponent<SpriteOutline>();
                if (spriteOutline != null)
                {
                spriteOutline.UpdateOutline(true);
                }
        }
            
            
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Herbs collidedHerb = collision.gameObject.GetComponent<Herbs>();
        if (collidedHerb != null)
        {
            
            SpriteOutline spriteOutline = collidedHerb.GetComponent<SpriteOutline>();

            
            if (spriteOutline != null)
            {
                spriteOutline.UpdateOutline(false);
            }

            carriedHerb = null;
        }
    }

}
