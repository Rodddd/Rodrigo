using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGolemSpriteChange : MonoBehaviour {

    public Sprite RockGolemHurt;
    SpriteRenderer thisSpriteRenderer;
    string nameOfSprite;
    private bool spawned = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Projectile"))
        {
            if (spawned)
            {
                if (other.CompareTag("Projectile"))
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = RockGolemHurt;
                }
            }
            spawned = true;

        }

    }
}
