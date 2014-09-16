using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PUnitClass : MonoBehaviour 
{
	public bool inAttackRange;
	public float attackSpeed;
	public float speed;
	public GameObject player;
	public Player playerScript;
	public float timer;
	public GameObject attackObject;
	public List<GameObject> inRangeList;
	public GameObject unitRegion;
	public GameObject pUnitRegion;
	public GameObject regionMiddle;
	public PUnitHealth pUnitHealth;
	
	void Awake()
	{
		pUnitHealth = GetComponent<PUnitHealth>();
		inAttackRange = false;
		inRangeList = new List<GameObject>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == Tags.unit)
		{
			inAttackRange = true;
			inRangeList.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == Tags.unit)
		{
			inAttackRange = false;
			inRangeList.Remove(other.gameObject);
		}
	}
}
