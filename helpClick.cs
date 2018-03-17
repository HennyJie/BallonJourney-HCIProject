using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class helpClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public Sprite noEnter;
	public Sprite didEnter;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerClick(PointerEventData eventData){
		if(eventData.pointerId == -1){
			SceneManager.LoadScene ("introduce1");
		}
	}

	public void OnPointerEnter(PointerEventData eventData){

		Button startBut = gameObject.GetComponent<Button>();
		startBut.GetComponent<Image> ().sprite = didEnter;
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (gameObject.GetComponent<RectTransform> ().sizeDelta.x + 10, gameObject.GetComponent<RectTransform> ().sizeDelta.y + 10);
//		GameObject.Find ("bird").GetComponent<Animation> ().Stop ();
	}

	public void OnPointerExit(PointerEventData eventData){

		Button startBut = gameObject.GetComponent<Button>();
		startBut.GetComponent<Image> ().sprite = noEnter;

		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (180, 102);
	}

}
