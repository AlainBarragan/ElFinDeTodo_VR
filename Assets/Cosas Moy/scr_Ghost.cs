using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ghost : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject,5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward*Time.deltaTime*5f);
	}
}
