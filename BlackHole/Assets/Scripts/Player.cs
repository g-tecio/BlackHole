using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	float timeCounter = 0;

	public float radius;
	public float speed;
    float x;
    float y;


    enum PlayerState{
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Oscillator();
		
	}



	//Jump Function
	public void Jump()
	{
        radius = 1;
        x = Mathf.Cos(timeCounter) * radius;
        y = Mathf.Sin(timeCounter) * radius;

        transform.position = new Vector2(x, y);
    }

    void Oscillator(){
		timeCounter += Time.deltaTime*speed;

		x = Mathf.Cos (timeCounter)*radius;
		y = Mathf.Sin (timeCounter)*radius;

        transform.position = new Vector2(x, y);
	}

    public void returnJump(){
        radius = 2;
        x = Mathf.Cos(timeCounter) * radius;
        y = Mathf.Sin(timeCounter) * radius;

        transform.position = new Vector2(x, y);
    }

	// void OnColliderEnter2D (Collider2D col)
	// {
	// 	if (col.gameObject.tag == "Enemy")
	// 	{
	// 		DestroyPlayer(col);
	// 		Debug.Log("Destroy");
	// 	}
		
	// }


}
