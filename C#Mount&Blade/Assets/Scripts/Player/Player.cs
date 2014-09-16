using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float speed;
	public float health;
	private Vector3 targetPos;
	private bool moveToMouseClick;
	private float stepSpeed;
	private int directionX;
	private int directionY;
	
	void Start () {
		health = 100.0f;
		directionX = -1;
		directionY = 1;
		speed = 5.0f;
		moveToMouseClick = false;
	}
	
	void FixedUpdate () {
		stepSpeed = Time.deltaTime * speed;
		
		if(Input.GetMouseButton(1))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = transform.position.z;
			CheckDirection(targetPos.x,targetPos.y,"mouse");
			moveToMouseClick = true;
			
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ResetMovement();
		}
		
		/*if(Input.GetKey(KeyCode.W)){
			moveToMouseClick = false;
			rigidbody2D.transform.position += Vector2.up * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.S)){
			moveToMouseClick = false;
			rigidbody2D.transform.position -= Vector2.up * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			moveToMouseClick = false;
			checkDirection(1,0);
			rigidbody2D.transform.position -= Vector2.right * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.D)){
			moveToMouseClick = false;
			checkDirection(-1,0);
			rigidbody2D.transform.position += Vector2.right * speed * Time.deltaTime;
		}*/
		
		if(moveToMouseClick)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, stepSpeed);
			if(transform.position == targetPos)
			{
				moveToMouseClick = false;
			}
		}
	}
	
	
	void ResetMovement()
	{
		moveToMouseClick = false;
	}
	
	void CheckDirection(float inputInX,float inputInY)
	{
		if(inputInX != 0 && inputInX != directionX)
		{
			//directionX = inputInX;
			//transform.localScale.x *= -1;
			/*if(directionX == 1)
		{
			//transform.position.x -= 1.0;
			transform.localScale.x *= -1;
		}
		else if(directionX == -1)
		{
			//transform.position.x += 1.0;
			transform.localScale.x *= -1;
		}*/
		}
	}
	
	void CheckDirection(float inputInX,float inputInY,string input)
	{
		int checkDir = directionX;
		if(inputInX > transform.position.x)
		{
			checkDir = -1;
		}
		else if(inputInX < transform.position.x)
		{
			checkDir = 1;
		}
		Debug.Log("c " + checkDir);
		Debug.Log("d " + directionX);
		if(checkDir != directionX)
		{
			directionX = checkDir;
			Vector3 tempScale = transform.localScale;
			tempScale.x *= -1;
			transform.localScale = tempScale;
		}
	}

	public void TakeDamage(float damageIn)
	{
		health -= damageIn;
	}
}
