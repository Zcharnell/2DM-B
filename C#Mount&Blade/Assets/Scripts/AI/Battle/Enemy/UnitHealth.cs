using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour 
{
	public float health = 100.0f;
	GameObject battleController;
	bool unitDead;

	void Awake()
	{
		battleController = GameObject.FindGameObjectWithTag(Tags.battleController);
	}

	void Update()
	{
		if(health <= 0 && !unitDead)
		{
			unitDead = true;
			UnitDeath();
		}
	}

	public void TakeDamage(int damageIn)
	{
		Debug.Log ("Take damage! " + damageIn);
		health -= damageIn;
	}

	void UnitDeath()
	{
		battleController.GetComponent<BattleController>().enemyUnitList.Remove (gameObject);
		Destroy(gameObject);
	}
}
