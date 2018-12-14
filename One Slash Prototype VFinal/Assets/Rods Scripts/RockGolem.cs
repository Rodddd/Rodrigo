using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGolem : MonoBehaviour {
    public float speed;
    public float stoppingDistence;
    public float retreatDistace;
    private bool spawned = false;
    private Transform player;
    private Transform rockgolem;
    //private float timeBtwShots;
    //public float startTimeBtwShots;
    //public GameObject projectile;
    //public GameObject Uppershot;
    //public GameObject Lowershot;
    private bool Vulnerable = false;

    // Use this for initialization

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rockgolem = GameObject.FindGameObjectWithTag("Rock Golem").transform;
     // timeBtwShots = startTimeBtwShots;
	}

    // Update is called once per frame
    void Update() {

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistence)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistence && Vector2.Distance(transform.position, player.position) > retreatDistace)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistace)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        //if (player.transform.position.y < rockgolem.transform.position.y)
        //{
            //print("upper");
            //uppershotenable = true;
            //lowershotenable = false;
        //}
        //else if (player.transform.position.y > rockgolem.transform.position.y)
        //{
            //print("lower");
            //lowershotenable = true;
            //uppershotenable = false;
        //}

        float distancetotarget = Vector3.Distance(transform.position, player.position);
        
            Vector3 targetdir = player.position - transform.position;
            float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            // if(timeBtwShots <= 0)
            {
         // Instantiate(projectile, transform.position, Quaternion.identity);
          //timeBtwShots = startTimeBtwShots;
        }
      //else
        {
          //timeBtwShots -= Time.deltaTime;
        }

	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            DestroyRockGolem();
        }

    }
    void DestroyRockGolem()
    {
        Destroy(gameObject);
    }
}
