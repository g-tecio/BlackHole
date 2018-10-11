using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float speed = 5f;



	enum PlayerState{
		Standing, Jumping
	}

	PlayerState currentState = PlayerState.Standing;



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
		MovePlayerLeft();

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

	//Movement of the player to the right
	void MovePlayerRight()
	{
		transform.Translate (speed * Time.deltaTime, 0,0);
	}

	void MovePlayerLeft()
	{
		transform.Translate (-speed * Time.deltaTime, 0,0);
	}

}
