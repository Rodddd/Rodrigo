using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Touch_Screen : MonoBehaviour
{

    public Swipes swipeControls;
    public Transform player;
    private Vector2 desiredPosition;
    private Vector2 tapPosition;
    private Vector2 target;
    public float speed;

    private void Start()
    {
        desiredPosition = player.transform.position;
    }

    private void Update()
    {

        if (swipeControls.SwipeLeft)
        {
            desiredPosition += Vector2.left;
        }

        if (swipeControls.SwipeRight)
        {
            desiredPosition += Vector2.right;
        }

        if (swipeControls.SwipeUp)
        {
            desiredPosition += Vector2.up;
        }

        if (swipeControls.SwipeDown)
        {
            desiredPosition += Vector2.down;
        }
        if (swipeControls.Tap)
        {
            print("Tap");
           Vector2.MoveTowards(player.transform.position,desiredPosition, speed * Time.deltaTime);
        }

        player.transform.position = Vector2.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
    }
}
