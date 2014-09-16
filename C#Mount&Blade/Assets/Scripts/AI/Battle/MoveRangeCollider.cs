using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveRangeCollider : MonoBehaviour 
{
	public List<GameObject> inMoveList;
	public bool inMoveRange;

	void Awake()
	{	
		inMoveList = new List<GameObject>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		inMoveRange = true;
		inMoveList.Add(other.gameObject);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		inMoveList.Remove(other.gameObject);
		if(inMoveList.Count < 1)
		{
			inMoveRange = false;
		}
	}
}
