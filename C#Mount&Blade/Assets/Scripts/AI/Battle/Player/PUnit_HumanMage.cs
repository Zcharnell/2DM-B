using UnityEngine;
using System.Collections;

public class PUnit_HumanMage : PUnitClass 
{
	//GameObject fireball;

	void Start()
	{
		pUnitHealth.health = 400f;
		attackSpeed = 2.0f;
		speed = 1.5f;
		player = GameObject.FindGameObjectWithTag(Tags.player);
		playerScript = player.GetComponent<Player>();
		unitRegion = GameObject.FindGameObjectWithTag(Tags.unitRegion);
		pUnitRegion = GameObject.FindGameObjectWithTag(Tags.pUnitRegion);
		regionMiddle = GameObject.FindGameObjectWithTag(Tags.region);
	}
	
	void Update()
	{
		timer += Time.deltaTime;
		//Debug.Log (attackSpeed + "  " + inAttackRange);
		//Debug.Log ("t" + timer);
		if(inAttackRange && timer > attackSpeed && inRangeList.Count > 0)
		{
			if(inRangeList[0] == null)
			{
				inRangeList.RemoveAt(0);
			}
			else
			{
				timer = 0.0f;
				Vector3 tempPos = transform.position;
				tempPos.x += 1;
				attackObject.GetComponent<PUnit_Fireball>().targetPos = inRangeList[0].transform.position;
				Instantiate(attackObject,tempPos,Quaternion.identity);
				//fireball.GetComponent<PUnit_Fireball>().enabled = true;
				inRangeList[0].GetComponent<UnitHealth>().TakeDamage (10);
				Debug.Log ("Enemy unit damaged! ");
			}
		}
		else if(!inAttackRange)
		{
			//...Need an array of all enemy units in the battle
			transform.position = Vector3.MoveTowards (transform.position,regionMiddle.transform.position,speed*Time.deltaTime);
		}
		else if(inRangeList.Count == 0 && inAttackRange)
		{
			inAttackRange = false;
		}
	}
}
