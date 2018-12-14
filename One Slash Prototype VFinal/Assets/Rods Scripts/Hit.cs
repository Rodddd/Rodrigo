using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {
    private PT_Basic_GameManager gameManager;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<PT_Basic_GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            gameManager.deaths++;
            // Destroy(other.gameObject);
            gameManager.RestartLevel();
        }
    }
}
