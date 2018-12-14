using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Bowls : MonoBehaviour {

    SpriteRenderer thisSpriteRenderer;
    string nameOfSprite;
    public Sprite Fire;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("change");
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //print("change");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Fire;
        }
    }
}
