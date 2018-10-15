using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGrav : MonoBehaviour {

	private Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		rig = this.GetComponent<Rigidbody2D>();
		rig.gravityScale = 1f;
		StartCoroutine("gravSet");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator gravSet()
	{
		yield return new WaitForSeconds(1);
		rig.gravityScale = 0f;
	}	
}
