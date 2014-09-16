using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : MonoBehaviour 
{
	public List<GameObject> playerUnitList;
	public List<GameObject> enemyUnitList;
	private GameObject[] unitObjs;
	private float timer;

	void Start()
	{
		timer = 0.0f;
		playerUnitList = new List<GameObject>();
		enemyUnitList = new List<GameObject>();
		unitObjs = GameObject.FindGameObjectsWithTag(Tags.playerUnit);
		foreach(GameObject unit in unitObjs)
		{
			playerUnitList.Add(unit);
		}
		unitObjs = GameObject.FindGameObjectsWithTag(Tags.unit);
		foreach(GameObject unit in unitObjs)
		{
			enemyUnitList.Add(unit);
		}
	}

	void Update()
	{
		timer += Time.deltaTime;
		Debug.Log ("PlayerUnitList: " + playerUnitList.Count);
		Debug.Log ("EnemyUnitList: " + enemyUnitList.Count);
		if(enemyUnitList.Count > 0)
		{
			Debug.Log ("EnemyUnitList: " + enemyUnitList[0]);
		}
		if(timer > 5.0f)
		{
			timer = 0.0f;
			ListUpdateCheck();
		}
	}

	void ListUpdateCheck()
	{
		//enemyUnitList.Remove (enemyUnitList.Find(null));
		/*foreach(GameObject unit in enemyUnitList)
		{
			if(unit == null)
			{
				enemyUnitList.Remove(unit);
			}
		}
		foreach(GameObject unit in playerUnitList)
		{
			if(unit == null)
			{
				playerUnitList.Remove(unit);
			}
		}*/
	}
}
