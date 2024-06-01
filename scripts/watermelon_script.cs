using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermelon_script : MonoBehaviour
{
    public float fallingspeed;
    private float Deadzone = -35f;
    private player_script player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_script>();
        if (player.is_on_tree)
            fallingspeed = player.falling_speed + 30f;
        else
            fallingspeed = player.falling_speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * fallingspeed) * Time.deltaTime;       //free falling
        if (transform.position.y < Deadzone)                                                             //destroying out of screen
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)                                                 //destroying on collision with player
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.shielded)
            {
                player.shielded = false;
                player.shield.SetActive(false);
            }
            else
            {
                player.watermelloned = true;
                player.anim.SetBool("is_falling", true);
                player.falling_speed *= 2;
            }
            Destroy(gameObject);
        }
    }
}
