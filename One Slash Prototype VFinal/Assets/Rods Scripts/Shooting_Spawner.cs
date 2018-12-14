using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Spawner : MonoBehaviour {

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private Transform player;
    private Transform rockgolem;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rockgolem = GameObject.FindGameObjectWithTag("Rock Golem").transform;
        timeBtwShots = startTimeBtwShots;
    }
	
	// Update is called once per frame
	void Update () {

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
