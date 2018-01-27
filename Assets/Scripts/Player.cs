using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

    private float movespeed;
    private List<Keystone> keystones;
    private List<BaseElement> elements;

	// Use this for initialization
	void Start () {
        movespeed = 5f;
        keystones = new List<Keystone>();
        elements = new List<BaseElement>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(movespeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f, movespeed * Input.GetAxis("Vertical") * Time.deltaTime);
	}
}
