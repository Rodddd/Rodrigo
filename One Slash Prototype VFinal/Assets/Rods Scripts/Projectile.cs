using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    private GameObject Fire;
    private Transform player;
    private Vector2 target;
    private bool spawned = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
	}

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            DestroyProjectile();
        }
        if ( other.CompareTag("Rock Golem"))
         {
            if (spawned)
            {
               DestroyProjectile();
            }
            spawned = true;
        }
        else if (other.CompareTag("Pillar"))
        {
            player = GameObject.FindGameObjectWithTag("Rock Golem").transform;
            target = new Vector2(player.position.x, player.position.y);
        }
    }

    void DestroyProjectile()
    {
       Destroy(gameObject);
    }
}
