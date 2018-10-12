using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	float timeCounter = 0;

	public float radius;
	public float speed;

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

	//Jump function, when the player is standing, can jump
 	void GetInput(){
		if(Input.GetMouseButton(0)){
			if(currentState == PlayerState.Standing)
			{
				Jump();
			}
			
		}
	}

	//Jump Function
	public void Jump()
	{
        radius = 1.5f;
		currentState = PlayerState.Jumping;
		Vector2 position = transform.position;

		rb.velocity = new Vector2(0,5);
	}

	//Collision with the floor
	void OnCollisionEnter2D(Collision2D other)
	{
		currentState = PlayerState.Standing;
		if (other.gameObject.tag == "top"){
			Physics2D.gravity = new Vector2 (0f, 9.8f);
		}
		if (other.gameObject.tag == "left"){
			Physics2D.gravity = new Vector2 (-9.8f, 0f);
		}
		if (other.gameObject.tag == "right"){
			Physics2D.gravity = new Vector2 (9.8f, 0f);
		}
		if (other.gameObject.tag == "bottom"){
			Physics2D.gravity = new Vector2 (0f, -9.8f);
		}
	}

	//Movement of the player to the right
	void MovePlayerRight()
	{
		transform.Translate (speed * Time.deltaTime, 0 ,1);
		
	}

	void MovePlayerLeft()
	{
		transform.Translate (-speed * Time.deltaTime, 0,0);
	}

	void Oscillator(){
		timeCounter += Time.deltaTime*speed;

		float x = Mathf.Cos (timeCounter)*radius;
		float y = Mathf.Sin (timeCounter)*radius;

        transform.position = new Vector2(x, y);

        if(Input.GetKey(KeyCode.Space)){
            radius = 1;
            x = Mathf.Cos(timeCounter) * radius;
            y = Mathf.Sin(timeCounter) * radius;

            transform.position = new Vector2(x, y);
        }else{
            radius = 2;
        }
		
	}

}
