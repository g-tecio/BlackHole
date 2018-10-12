using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour {

    public GameObject DeathEffectObj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
            GameObject effectObj = Instantiate(DeathEffectObj, col.contacts[0].point, Quaternion.identity);
            Destroy(effectObj, 0.5f);
            Destroy (col.gameObject);
		}
	}
}
