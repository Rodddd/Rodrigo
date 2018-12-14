using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapRoll : MonoBehaviour {
    public KeyCode tapLeft;
    public KeyCode tapRight;
    public KeyCode tapUp;
    public KeyCode tapDown;

    public int leftTotal = 0;
    public int rightTotal = 0;
    public int upTotal = 0;
    public int downTotal = 0;
    public float leftTimeDelay = 0;
    public float rightTimeDelay = 0;
    public float upTimeDelay = 0;
    public float downTimeDelay = 0;

    public float RollDuration;

    public int xVel = 0;
    // Use this for initialization
    void Start () {
		
	}
#if UNITY_EDITOR
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(tapRight))
            {
               GetComponent<Rigidbody2D>().velocity = new Vector3(4 + xVel, 0, 0);
            }

            if (Input.GetKeyDown(tapRight))
            {
                rightTotal += 1;
            }

            if (Input.GetKeyUp(tapRight))
            {
                xVel = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            if ((rightTotal == 1) && (rightTimeDelay < .3))
                rightTimeDelay += Time.deltaTime;

            if ((rightTotal == 1) && (rightTimeDelay >= .3))
            {
                rightTimeDelay = 0;
                rightTotal = 0;
            }

            if ((rightTotal == 2) && (rightTimeDelay < .3))
            {
                xVel = 3;
                rightTotal = 0;
            }

            if ((rightTotal == 2) && (rightTimeDelay >= .3))
            {
                xVel = 0;
                rightTotal = 0;
                rightTimeDelay = 0;
            }

            if (xVel == 3)
            {
                RollDuration += Time.deltaTime;
            }
            if (RollDuration > .6)
            {
                xVel = 0;
                RollDuration = 0;
                rightTotal = 0;
                rightTimeDelay = 0;
            }

        if (Input.GetKey(tapLeft))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(-4 + xVel, 0, 0);
            }

        if (Input.GetKeyDown(tapLeft))
            {
                leftTotal += 1;
            }

        if (Input.GetKeyUp(tapLeft))
            {
                xVel = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            if ((leftTotal == 1) && (leftTimeDelay < .3))
                leftTimeDelay += Time.deltaTime;

            if ((leftTotal == 1) && (leftTimeDelay >= .3))
            {
                leftTimeDelay = 0;
                leftTotal = 0;
            }

            if ((leftTotal == 2) && (leftTimeDelay < .3))
            {
                xVel = -3;
                leftTotal = 0;
            }

            if ((leftTotal == 2) && (leftTimeDelay >= .3))
            {
                xVel = 0;
                leftTotal = 0;
                leftTimeDelay = 0;
            }

            if (xVel == -3)
            {
                RollDuration += Time.deltaTime;
            }
            if (RollDuration > .6)
            {
                xVel = 0;
                RollDuration = 0;
                leftTotal = 0;
                leftTimeDelay = 0;
            }

        if (Input.GetKey(tapUp))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 4 + xVel, 0);
            }

            if (Input.GetKeyDown(tapUp))
            {
                upTotal += 1;
            }

            if (Input.GetKeyUp(tapUp))
            {
                xVel = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            if ((upTotal == 1) && (upTimeDelay < .3))
                upTimeDelay += Time.deltaTime;

            if ((upTotal == 1) && (upTimeDelay >= .3))
            {
                upTimeDelay = 0;
                upTotal = 0;
            }

            if ((upTotal == 2) && (upTimeDelay < .3))
            {
                xVel = 3;
                upTotal = 0;
            }

            if ((upTotal == 2) && (upTimeDelay >= .3))
            {
                xVel = 0;
                upTotal = 0;
                upTimeDelay = 0;
            }

            if (xVel == 3)
            {
                RollDuration += Time.deltaTime;
            }
            if (RollDuration > .6)
            {
                xVel = 0;
                RollDuration = 0;
                upTotal = 0;
                upTimeDelay = 0;
            }

        if (Input.GetKey(tapDown))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, -4 + xVel, 0);
            }

            if (Input.GetKeyDown(tapDown))
            {
                downTotal += 1;
            }

            if (Input.GetKeyUp(tapDown))
            {
                xVel = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }

            if ((downTotal == 1) && (downTimeDelay < .3))
                downTimeDelay += Time.deltaTime;

            if ((downTotal == 1) && (downTimeDelay >= .3))
            {
                downTimeDelay = 0;
                downTotal = 0;
            }

            if ((downTotal == 2) && (downTimeDelay < .3))
            {
                xVel = -3;
                downTotal = 0;
            }

            if ((downTotal == 2) && (downTimeDelay >= .3))
            {
                xVel = 0;
                downTotal = 0;
                downTimeDelay = 0;
            }

            if (xVel == -3)
            {
                RollDuration += Time.deltaTime;
            }
            if (RollDuration > .6)
            {
                xVel = 0;
                RollDuration = 0;
                downTotal = 0;
                downTimeDelay = 0;
            }

    }
#endif

}
