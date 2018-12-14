using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Charge : MonoBehaviour
{

    public float speed;
    public float stoppingDistence;
    public float LockOn;
    public float Charge;
    private float Stoptimer = 1.5f;
    private float ChargeTimer;
    private Transform player;
    private Transform Knight;
    private Vector2 target;
    private bool isCharging;
    private float AfterCharge;
    private bool DoCharge;
    private bool Vulnerable = false;
    float lockpos = 0;
    private PT_Danger DangerScript;
    public float PillarHitTimer;
    private bool hitpillar = false;
    //public Sprite KnightHurt;
    // SpriteRenderer thisSpriteRenderer;
    // string nameOfSprite;
    // Use this for initialization
    void Start()
    {
        isCharging = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2 (player.position.x, player.position.y);
        DangerScript = GetComponent<PT_Danger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Vector2.Distance(transform.position, player.position) > LockOn)
        {
            //print("Lock");
            transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos);
        }

        else if (Vector2.Distance(transform.position, player.position) < LockOn)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistence && !DoCharge && AfterCharge <= Time.time && !isCharging && !hitpillar)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                ChargeTimer = Time.time + Stoptimer;
                //print("Im Moving!");
            }
            else if (!isCharging && AfterCharge <= Time.time && !DoCharge && !hitpillar)
            {
                //print("Charging up");
                //if (Vector2.Distance(transform.position, player.position) < stoppingDistence && Vector2.Distance(transform.position, player.position) > Charge)
                ChargeTimer = Time.time + Stoptimer;
                isCharging = true;
                // print("Charging upppS");

            }
        }
        //if(Vulnerable == true)
        //{
        //    if (PillarHit > )
        //    {
        //        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos;
        //    }
        //}
        //if (Vector2.Distance(transform.position, player.position) == stoppingDistence && !isCharging)
        //{


        //}
        if (ChargeTimer <= Time.time && isCharging && !DoCharge && !hitpillar)
        {
           // print("charge");
            target = new Vector2(player.position.x, player.position.y);
            isCharging = false;
            DoCharge = true;
        }
        
        if (DoCharge && ChargeTimer <= Time.time && !hitpillar)
        {
           // print("In Charge!!");
            transform.position = Vector2.MoveTowards(transform.position, target, Charge * Time.deltaTime);
            if (gameObject.transform.position.x == target.x && gameObject.transform.position.y == target.y)
            {
                DoCharge = false;
                AfterCharge = Time.time + 2;
                //print("change");
            }


        }
        // else if (Vector2.Distance(transform.position, player.position) < Charge)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (hitpillar && PillarHitTimer<= Time.time)
        {
            hitpillar = false;
            Vulnerable = false;
            AfterCharge = Time.time;

        }
        if (hitpillar)
        {
            Vulnerable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            hitpillar = true;
            Vulnerable = true;
            //print("VulOn");
            DangerScript.isDangours = false;
            PillarHitTimer = Time.time + 1;

        }

        if (Vulnerable == true)
        {
            if (other.CompareTag("Player"))
            {
                DestroyKnight();
                //print("die");
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pillar"))
        {
            print("Back");
            if (Vulnerable)
            {
                Vulnerable = false;
                DangerScript.isDangours = true;
            }
        }
    }
    void DestroyKnight()
    {
        Destroy(gameObject);
    }
}
