using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class toIntro2 : MonoBehaviour, IPointerClickHandler{


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerClick(PointerEventData eventData){
		if(eventData.pointerId == -1){
			SceneManager.LoadScene ("introduce2");
		}
	}

}
