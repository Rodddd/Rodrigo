using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Change : MonoBehaviour {
    public Sprite KnightHurt;
    public Sprite Knight;
    SpriteRenderer thisSpriteRenderer;
    string nameOfSprite;
   // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("change");
        if (collision.gameObject.CompareTag("Pillar"))
        {
            //print("change");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = KnightHurt;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //print("change");
        if (collision.gameObject.CompareTag("Pillar"))
        {
            //print("change");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Knight;
        }
    }
}
