using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fruit_spawner : MonoBehaviour
{
    public GameObject banana;
    public GameObject strawberry;
    public GameObject watermelon;
    public GameObject lemon;
    public GameObject cherry;
    private banana_script banana_script;
    private strawberry_script strawberry_script;
    private watermelon_script watermelon_script;
    private lemon_script lemon_script;
    private cherry_script cherry_script;
    public float banana_spawn_time = 3f;
    public float strawberry_spawn_time = 5f;
    public float watermelon_spawn_time = 7.5f;
    public float lemon_spawn_time = 15f;
    public float cherry_spawn_time = 15f;
    private float strawberry_timer;
    private float banana_timer;
    private float watermelon_timer;
    private float lemon_timer;
    private float cherry_timer;
    private LogicScript logic;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("Player");
        banana_script = banana.GetComponent<banana_script>();
        strawberry_script = strawberry.GetComponent<strawberry_script>();
        watermelon_script = watermelon.GetComponent<watermelon_script>();
        lemon_script = lemon.GetComponent<lemon_script>();
        cherry_script = cherry.GetComponent<cherry_script>();
        banana_timer = 0f;
        strawberry_timer = 0f;
        watermelon_timer = 0f;
        lemon_timer = 0f;
        cherry_timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(watermelon_timer > watermelon_spawn_time && logic.Score>=100)         //watermelon spawn every 7.5sec after 100 points
        {
            Watermelon_Spawn();
            watermelon_timer = 0f;
        }
       if(banana_timer > banana_spawn_time)                    //banana spawn every 3sec
        {
            Banana_Spawn();
            banana_timer = 0f;
        }
       if(strawberry_timer > strawberry_spawn_time)            //strawberry spawn every 5sec
        {
            Strawberry_Spawn();
            strawberry_timer = 0f;
        }
       if(lemon_timer > lemon_spawn_time)                      //lemon spawn every 15sec
        {
            Lemon_Spawn();
            lemon_timer = 0f;
        }
       if(cherry_timer > cherry_spawn_time)                    //cherry spawn every 15sec
        {
            Cherry_Spawn();
            cherry_timer = 0f;
        }
        if(logic.isAlive)                                     //add time to timers
        {
            strawberry_timer += Time.deltaTime;
            banana_timer += Time.deltaTime;
            watermelon_timer += Time.deltaTime;
            lemon_timer += Time.deltaTime;
            cherry_timer += Time.deltaTime;
        }
    }

    void Strawberry_Spawn()                 //function to spawn strawberries
    {
        Instantiate(strawberry, new Vector3(Random.Range(-20, 20), 36, -1), transform.rotation=Quaternion.Euler(-90,0,0));           //rotation because sprite from unity store is rotated in the wrong direction
    }
    void Banana_Spawn()                     //function to spawn bananas
    {
        Instantiate(banana, new Vector3(Random.Range(-25, 25), 36, -3), transform.rotation=Quaternion.Euler(-90,0,0));               //rotation because sprite from unity store is rotated in the wrong direction
    }
    void Watermelon_Spawn()                 //function to spawn watermelons
    {
        Instantiate(watermelon, new Vector3(Random.Range(-20, 20), 36, -1), transform.rotation=Quaternion.Euler(-135,0,0));        //rotation because sprite from unity store is rotated in the wrong direction
    }
    void Lemon_Spawn()                      //function to spawn lemons
    {
        Instantiate(lemon, new Vector3(Random.Range(-25, 25), 36, -1), transform.rotation=Quaternion.Euler(-135,0,0));                 //rotation because sprite from unity store is rotated in the wrong direction
    }
    void Cherry_Spawn()                     //function to spawn cherries
    {
        Instantiate(cherry, new Vector3(Random.Range(-35, 35), 36, -1), transform.rotation=Quaternion.Euler(-90,0,0));               //rotation because sprite from unity store is rotated in the wrong direction
    }
}
