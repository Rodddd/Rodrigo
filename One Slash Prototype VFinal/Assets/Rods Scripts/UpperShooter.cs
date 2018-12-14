using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperShooter : MonoBehaviour {

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    //public GameObject Uppershot;
    //public GameObject Lowershot;
    private Transform player;
    private Transform rockgolem;
    //private bool Lowershotenable;
    //private bool Uppershotenable;
    

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rockgolem = GameObject.FindGameObjectWithTag("Rock Golem").transform;
        timeBtwShots = startTimeBtwShots;
        //Uppershotenable = false;
        //Lowershotenable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        //if (player.transform.position.y >rockgolem.transform.position.y)
        //{
            //print("upper");
            //Uppershotenable = true;
            //Lowershotenable = false;
        //}
        //else if (player.transform.position.y < rockgolem.transform.position.y)
        //{
            //print("lower");
            //Uppershotenable = false;
            //Lowershotenable = true;
        //}


    }
}
