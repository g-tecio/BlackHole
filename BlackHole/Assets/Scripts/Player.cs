using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float jumpForce;
	public int moveSpeed = 0;
	private Rigidbody2D rb;
	private float moveInput;
	public Transform feetPos;
	public float checkRadius;
	public LayerMask whatIsGround;
	
	


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
		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

		if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
			rb.velocity = Vector2.up * jumpForce;
		}
	}
	

	void MovePlayer()
	{
		this.transform.position += transform.right * moveSpeed * Time.deltaTime;
		
		
	}



}
