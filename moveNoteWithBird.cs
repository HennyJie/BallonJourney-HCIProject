using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class moveNoteWithBird : MonoBehaviour {

	public GameObject noteObject;
	public GameObject birdObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		noteObject.transform.position = birdObject.transform.position;
	}
}
