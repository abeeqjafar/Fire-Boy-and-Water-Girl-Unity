using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
	public float speed = 6;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "RedPlayer" && Input.GetKey(KeyCode.W))
		{
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

		}
		if (other.tag == "BluePlayer" && Input.GetKey(KeyCode.UpArrow))
		{
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

		}
		else if (other.tag == "RedPlayer" && Input.GetKey(KeyCode.S))
		{
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
		}
		else if (other.tag == "BluePlayer" && Input.GetKey(KeyCode.DownArrow))
		{
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
		}
		else
		{

			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);

		}

	}

}
