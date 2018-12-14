using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{

    public Transform[] patrolpoints;
    public float speed;
    Transform currentpatrolpoint;
    int currentpatrolindex;

    public Transform player;
    public float chaserange;

    void Start()
    {
        currentpatrolindex = 0;
        currentpatrolpoint = patrolpoints[currentpatrolindex];
    }

    void Update()
    {
        float distancetotarget = Vector3.Distance(transform.position, player.position);
        if (distancetotarget < chaserange)
        {
            Vector3 targetdir = player.position - transform.position;
            float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}

