using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public float delay = 2.0f;
    public float pos_y = 0.0f;
    public bool active = false;
    public Vector2 delayRange = new Vector2(0.5f, 1);
    public Vector2 positionRange = new Vector2(-4, 4);
    public float pos_x = 0.0f;

    void ResetRange()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
        pos_y = Random.Range(positionRange.x, positionRange.y);
        pos_x = 4 + pos_x;
        
    }

    // Use this for initialization
    void Start () {
        ResetRange();
        StartCoroutine(CloudGenerator());
	}

    IEnumerator CloudGenerator()
    {
        yield return new WaitForSeconds(delay);
        if (active)
        {
            var newTransform = transform;
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(pos_x, pos_y, 0), Quaternion.identity);
            ResetRange();
        }
        StartCoroutine(CloudGenerator());
    }

	// Update is called once per frame
	void Update () {
		
	}
}
