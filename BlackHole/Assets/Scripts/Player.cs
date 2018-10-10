using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
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
	}

	void GetInput(){
		if(Input.GetMouseButton(0)){
			if(currentState == PlayerState.Standing)
			{
				Jump();
			}
			
		}
	}

	void Jump()
	{
		currentState = PlayerState.Jumping;
		rb.velocity = new Vector2(0,5);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		currentState = PlayerState.Standing;
	}
}
