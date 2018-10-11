using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

	//Array of waypints to walk from one to the next one
	[SerializeField]
	private Transform[] waypoints;

	//Walk speed that can be set in Inspector
	[SerializeField]
	private float moveSpeed = 2f;

	//Index of current waypoint from which Player walks to the next one
	private int waypointIndex = 0;


	// Use this for initialization
	void Start () {
		
		//Set position of Enemy as position of the first waypoint
		transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	private void Move()
	{
		//If player did not reach last waypoint it can move
		//If player reached last waypoint the it stops
		if (waypointIndex <= waypoints.Length - 1)
		{
			//Move Enemy from current waypoint to the next one
			//Using movetowards method
			transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

			//If player reach position of waypoint he walked towards then waypointIndex is increased by 1 and enemy starts to walk to the next waypoint

			if (transform.position == waypoints[waypointIndex].transform.position)
			{
				waypointIndex += 1;
			}
		}
	}
}
