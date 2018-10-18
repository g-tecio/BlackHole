using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float RotateSpeed = 1.5f;
	public Transform Target;
	private Vector3 zAxis = new Vector3(0,0,1);

	public float jumpForce;

	 Rigidbody2D rb;
	private float moveInput;

	enum PlayerState{
		Standing, Jumping, Falling
	}

	PlayerState currentState = PlayerState.Falling;


	


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		MovePlayer();
		
		
	}

	void Update()
	{
		GetInput();
	}

	void GetInput()
	{
		if (Input.GetMouseButton(0))
		{
			if (currentState == PlayerState.Standing)
			{
				Jump();
			}
		}
	}

    public void Jump()
	{
		currentState = PlayerState.Jumping;
		rb.AddForce(transform.position * jumpForce);
	}
	

	void MovePlayer()
	{
	
		this.transform.RotateAround(Target.position,zAxis,RotateSpeed);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		currentState = PlayerState.Standing;
	}



}
