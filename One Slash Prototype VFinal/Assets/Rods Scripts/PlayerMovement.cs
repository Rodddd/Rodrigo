using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    private Vector2 Direction;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
	{
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    private void GetInput()
    {
        Direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) 
        {
            Direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector2.up;
        }
    }
}
