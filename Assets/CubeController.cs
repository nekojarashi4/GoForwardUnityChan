using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    private float speed = -0.2f;

    private float deadLine = -10;

    private float groundLevel = -3.0f;

    public AudioSource AS;

    public AudioClip A;

    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
        AS.clip = A;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(this.speed, 0, 0);

        bool isGround = (transform.position.y >= this.groundLevel) ? false : true;

        //if (transform.position.y <= this.groundLevel)
        //{
            GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        //}


        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Cube")
        {
            //AS.PlayOneShot(A);
            AS.Play();
        }
    }
}
