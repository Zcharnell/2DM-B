using UnityEngine;
using System.Collections;

public class DetectionArea : MonoBehaviour {

	public LordAI ai;
	public GameObject player;
	
	void Awake()
	{
		ai = transform.parent.GetComponent<LordAI>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject == player)
		{
			
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject == player)
		{
			ai.setFollow(player);
			Debug.Log("Player in collider");
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == player)
		{
			Debug.Log("Player exits collider");
			ai.endFollow();
		}
	}
}
