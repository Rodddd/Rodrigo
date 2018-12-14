using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector2 startPos, endPos, direction;
    float touchTimerStart, touchTimerFinish, timeInterval;
    [Range(0.05f, 1f)]
    public float throwForse = 0.3f;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        {
            touchTimerStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
            touchTimerFinish = Time.time;
            timeInterval = touchTimerFinish - touchTimerStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
        }
    }
}
