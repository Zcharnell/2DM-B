using UnityEngine;
using System.Collections;

public class FireballSlow : MonoBehaviour 
{
	public Vector3 targetPos;
	public GameObject player;
	public float speed;
	public GameObject fireballExplosion;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player);
		targetPos = player.GetComponent<PlayerAttack>().targetPos;
		speed = 10.0f;
	}
	
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
		if(transform.position == targetPos)
		{
			Explode();
		}
	}
	
	void Explode()
	{
		Instantiate(fireballExplosion,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
}
