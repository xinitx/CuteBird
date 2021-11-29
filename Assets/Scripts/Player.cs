using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player instance;

    private Vector2 down;
    private Vector2 up;

    [Header("»·¾³¼ì²â")]
    public float HeadOffset;
    public float GroundDistance;
    public LayerMask ground;
    public bool HeadCheck = false;

    public bool Isdead = false;
    public bool Iswin = false;

    public Bag bag;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        Continue();
        transform.position = new Vector3(bag.first[bag.Level].x, bag.first[bag.Level].y, transform.position.z);
    }
        void Update()
    {

        Move();
        PhysicsCheck();
    }

    public void Move()
    {
            if(Input.anyKey)
            transform.position += new Vector3( up.x * Time.deltaTime, up.y * Time.deltaTime, 0);
        transform.position += new Vector3(down.x * Time.deltaTime, down.y * Time.deltaTime, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            Isdead = true;
        }
        if (collision.CompareTag("Final"))
        {
            Iswin = true;
        }
    }
    void PhysicsCheck()
    {
        Vector2 pos = transform.position;
        Vector2 Offset = new Vector2(0, HeadOffset);
        RaycastHit2D headjud = Physics2D.Raycast(pos + Offset, Vector2.up, GroundDistance,ground);
        Debug.DrawRay(pos + Offset, Vector2.up, Color.red, GroundDistance);

        if (headjud)
        {
            HeadCheck = true;
        }
        else HeadCheck = false;
    }

    public static void Pause()
    {
        instance.down = new Vector2(0, 0);
        instance.up = new Vector2(0, 0);
    }
    public static void Continue()
    {
        instance.down = new Vector2(4, -4);
        instance.up = new Vector2(0, 30);
        UIManage.closemenu();
        UIManage.closeGameover();
    }


    
}
