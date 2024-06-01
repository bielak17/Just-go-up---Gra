using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public TrailRenderer trail;
    public GameObject stun;
    public GameObject shield;
    public Image speed_timer;
    public Image stun_timer;
    public float speed = 25f;
    public float falling_speed = 40f;
    public bool is_on_tree = false;
    public bool bonus_speed = false;
    public bool stunned = false;
    public bool watermelloned = false;
    public bool shielded = false;
    public float bonus_speed_time;
    public float stunned_time;
    private LogicScript Logic;

    // Start is called before the first frame update
    void Start()
    {
        Logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();
        Logic.isAlive = true;
        trail.emitting = false;
        stun.SetActive(false);
        shield.SetActive(false);
        stun_timer.fillAmount = 0;
        speed_timer.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Logic.isAlive)
        {
            if(!stunned && !watermelloned)
                getmove();
            rb.transform.position += Vector3.down * falling_speed * Time.deltaTime;         //free falling
            if (rb.transform.position.y < -34)                                              //game over if player falls off screen
            {
                Logic.isAlive = false;
                Destroy(gameObject);
                Logic.gameOver();
            }
        }
        if (bonus_speed && bonus_speed_time!=0)
        {
            bonus_speed_time -= Time.deltaTime;
            speed_timer.fillAmount = bonus_speed_time / 2f;
        }
        if(bonus_speed && bonus_speed_time<=0)
        {
            speed -= 10;
            bonus_speed = false;
            trail.emitting = false;
            bonus_speed_time = 0;
        }
        if (stunned && stunned_time != 0)
        {
            stunned_time -= Time.deltaTime;
            stun_timer.fillAmount = stunned_time / 1.25f;
        }
        if (stunned && stunned_time <= 0)
        {
            stunned = false;
            stun.SetActive(false);
            stunned_time = 0;
        }
    }
    void getmove()                          //function to move the player using wsad or arrow keys
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && is_on_tree && rb.transform.position.y < 26)
        {
            rb.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && is_on_tree)
        {
            rb.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && rb.transform.position.x > -37)
        {
            rb.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && rb.transform.position.x < 37)
        {
            rb.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}