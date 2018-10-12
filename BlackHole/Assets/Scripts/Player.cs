using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    float timeCounter = 0;

    public float radius;
    public float speed;
    bool isJump = false;
    float x;
    float y;


    enum PlayerState
    {
        Standing, Jumping
    }

    PlayerState currentState;



    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        radius = 2;
        speed = 1;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Oscillator();

    }



    //Jump Function
    public void Jump()
    {
        if (isJump == false)
        {
            isJump = true;
            radius = 1;
            x = Mathf.Cos(timeCounter) * radius;
            y = Mathf.Sin(timeCounter) * radius;

            transform.position = new Vector2(x, y);
        }
    }

    void Oscillator()
    {
        timeCounter += Time.deltaTime * speed;

        x = Mathf.Cos(timeCounter) * radius;
        y = Mathf.Sin(timeCounter) * radius;

        transform.position = new Vector2(x, y);
    }

    public void returnJump()
    {
        if (isJump == true)
        {
            isJump = false;
            radius = 2;
            x = Mathf.Cos(timeCounter) * radius;
            y = Mathf.Sin(timeCounter) * radius;

            transform.position = new Vector2(x, y);
        }
    }
}
