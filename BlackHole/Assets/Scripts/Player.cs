using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	float angle = 0;
	int xSpeed = 2;

	enum PlayerState{
		Standing, Jumping, Falling
	}

	PlayerState currentState = PlayerState.Falling;



	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		MovePlayer();
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
	void Jump()
	{
		currentState = PlayerState.Jumping;
		rb.velocity = new Vector2(0,5);
	}

	//Collision with the floor
	void OnCollisionEnter2D(Collision2D other)
	{
		currentState = PlayerState.Standing;
	}

	//Movement of the player
	void MovePlayer()
	{
		Vector2 pos = transform.position;
		pos.x = Mathf.Cos(angle)*5;
		
		transform.position = pos;
		angle += Time.deltaTime * xSpeed;
	}

}
