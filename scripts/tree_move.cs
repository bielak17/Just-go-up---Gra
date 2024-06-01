using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_move : MonoBehaviour
{
    public float ramping_speed;
    private LogicScript Logic;
    private player_script move;
    // Start is called before the first frame update
    void Start()
    {
        ramping_speed=2.5f;
        Logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        move=GameObject.FindGameObjectWithTag("Player").GetComponent<player_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-109)
        {
            transform.position=new Vector3(0,50,0);
        }
        if (Logic.isAlive)
        {
            transform.Translate(Vector3.down*ramping_speed*Time.deltaTime);         //tree moving down
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)                 //moving allowed only on tree
    {
        if(collision.gameObject.tag=="Player")
        {
            move.is_on_tree=true;
            move.anim.SetBool("is_falling",false);
            move.falling_speed-=30;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)                  //moving not allowed off tree
    {
        if(collision.gameObject.tag=="Player")
        {
            move.is_on_tree=false;
            move.anim.SetBool("is_falling",true);
            move.falling_speed+=30;
        }
    }
}
