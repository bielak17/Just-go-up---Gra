using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_background : MonoBehaviour
{
    private int background_option;
    public float ramping_speed;
    private LogicScript logic;
    [SerializeField]private Sprite forest;
    [SerializeField]private Sprite beach;

    // Start is called before the first frame update
    void Start()
    {
        background_option = PlayerPrefs.GetInt("Background", 1);
        if (background_option == 1)
            GetComponent<SpriteRenderer>().sprite = forest;
        else if(background_option == 2)
            GetComponent<SpriteRenderer>().sprite = beach;
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-121f)
        {
            transform.position=new Vector3(0,-61f,1);
        }
        if (logic.isAlive)
        {
            transform.Translate(Vector3.down*ramping_speed*Time.deltaTime);       //changing background
        }
    }
}
