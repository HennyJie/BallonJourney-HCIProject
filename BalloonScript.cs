using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    // Use this for initialization
    public Vector2 speed = new Vector2(2, 10);
    private Vector2 movement;
    public bool kill = false;
    public Spawner spawner;

    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        System.Console.WriteLine("X:"+inputX+"  Y:"+inputY);
       
        movement = new Vector2(
            speed.x,
            speed.y * inputY
            );
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        spawner.active = false;
        AudioSource au = GameObject.Find("bombAudio").GetComponent<AudioSource>();
        au.volume = 100*au.volume;
        au.Play();
    }
}
