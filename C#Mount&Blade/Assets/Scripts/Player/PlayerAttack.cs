using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public Vector3 targetPos;
	public GameObject fireball;
	public GameObject fireballSlow;
	public GameObject iceball;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = transform.position.z;
			Ability1();
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = transform.position.z;
			Ability2();
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = transform.position.z;
			Ability3();
		}
	}

	void Ability1()
	{
		Instantiate(fireball,transform.position,Quaternion.identity);
	}

	void Ability2()
	{
		Instantiate(fireballSlow,transform.position,Quaternion.identity);
	}

	void Ability3()
	{
		Instantiate(iceball,transform.position,Quaternion.identity);
	}
}
