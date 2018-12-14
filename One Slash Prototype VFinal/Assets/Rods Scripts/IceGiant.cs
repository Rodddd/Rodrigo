using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGiant : MonoBehaviour {

    public float speed;
    public float stoppingDistence;
    public float retreatDistace;
    private Transform player;
    private Transform icegiant;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        icegiant = GameObject.FindGameObjectWithTag("Ice Giant").transform;
    }
	
	// Update is called once per frame
	void Update () {
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
        float distancetotarget = Vector3.Distance(transform.position, player.position);

        Vector3 targetdir = player.position - transform.position;
        float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyIceGiant();
        }
    }

    void DestroyIceGiant()
    {
        Destroy(gameObject);
    }
}
