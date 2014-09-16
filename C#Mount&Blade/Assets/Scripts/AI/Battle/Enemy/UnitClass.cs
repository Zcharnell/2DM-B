using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitClass : MonoBehaviour 
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
	public UnitHealth unitHealth;
	public MoveRangeCollider moveRangeCollider;

	void Awake()
	{
		moveRangeCollider = transform.Find("MoveRangeCollider").gameObject.GetComponent<MoveRangeCollider>();
		unitHealth = GetComponent<UnitHealth>();
		inAttackRange = false;
		inRangeList = new List<GameObject>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == Tags.player || other.tag == Tags.playerUnit)
		{
			inAttackRange = true;
			inRangeList.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == Tags.player || other.tag == Tags.playerUnit)
		{
			inRangeList.Remove(other.gameObject);
			if(inRangeList.Count < 1)
			{
				inAttackRange = false;
			}
		}
	}
}
