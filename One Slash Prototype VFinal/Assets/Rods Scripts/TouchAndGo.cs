using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndGo : MonoBehaviour {

    //[SerializeField]
    public float moveSpeed;
    public float rollSpeed;
    //public float slashSpeed;

    Rigidbody2D rb;

    Touch touch;
    Vector3 touchPostion, whereToMove;
    bool isMoving = false;
    bool isRolling = false;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
#if UNITY_ANDROID 
    // Update is called once per frame
    void Update () {
        if (isMoving)
            currentDistanceToTouchPos = (touchPostion - transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPostion = Camera.main.ScreenToWorldPoint(touch.position);
                touchPostion.z = 0;
                whereToMove = (touchPostion - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
            }

            //if (touch.phase == TouchPhase.Stationary)
            //{
            //    previousDistanceToTouchPos = 0;
            //    currentDistanceToTouchPos = 0;
            //    isRolling = true;
            //    touchPostion = Camera.main.ScreenToWorldPoint(touch.position);
            //    touchPostion.z = 0;
            //    whereToMove = (touchPostion - transform.position).normalized;
            //    rb.velocity = new Vector2(whereToMove.x * rollSpeed, whereToMove.y * rollSpeed);
            //}

            if (touch.phase == TouchPhase.Moved)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isRolling = true;
                touchPostion = Camera.main.ScreenToWorldPoint(touch.position);
                touchPostion.z = 0;
                whereToMove = (touchPostion - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * rollSpeed, whereToMove.y * rollSpeed);
            }
        }
        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
            previousDistanceToTouchPos = (touchPostion - transform.position).magnitude;
	}
#endif
}
