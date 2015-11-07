using UnityEngine;
using System.Collections;

public class robotMove : MonoBehaviour
{

    public float Speed;
    public float jumpHeight;
    public bool isJumping = false;

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
             
       
    }


    // Update is called once per frame
    void FixedUpdate()
    { 
		//Jumping
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!isJumping)
			{
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}
		}
		//Movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
		//Make object black
		if (col.gameObject.tag == "ColorTrigger") 
		{
			SpriteRenderer colorBox = GameObject.FindGameObjectWithTag("ColorTrigger").GetComponent<SpriteRenderer>();
			colorBox.color = new Color(0, 0, 0, 1);
		}

    }

	void OnTriggerEnter2D(Collider2D col)
	{
		//Make player jump
		if (col.gameObject.tag == "JumpTrigger") 
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpHeight);
			Debug.Log("JumpTrigger");
		}
		//Revert color back
		if (col.gameObject.tag == "unColorTrigger")
		{
			SpriteRenderer colorBox = GameObject.FindGameObjectWithTag("ColorTrigger").GetComponent<SpriteRenderer>();
			colorBox.color = new Color(1, 1, 1, 1);
		}
	}



}
