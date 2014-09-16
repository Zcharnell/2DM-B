using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float cameraSpeed;
	
	void Awake()
	{
		cameraSpeed = 10.0f;
	}
	
	void Update() 
	{
		// transform.Translate(Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0));
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
		{
			//transform.Translate(Vector2.up * cameraSpeed * Time.deltaTime);
			Vector3 tempTrans = transform.position;
			tempTrans.y += Input.GetAxis("Vertical")*cameraSpeed*Time.deltaTime;
			transform.position = tempTrans;
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 tempTrans = transform.position;
			tempTrans.x += Input.GetAxis("Horizontal")*cameraSpeed*Time.deltaTime;
			transform.position = tempTrans;
		}
	}
}
