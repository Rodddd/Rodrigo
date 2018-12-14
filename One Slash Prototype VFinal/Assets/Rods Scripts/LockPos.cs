using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPos : MonoBehaviour {
    float lockpos = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos);
	}
}
