using UnityEngine;
using System.Collections;

public class PUnitHealth : MonoBehaviour 
{
	public float health = 100.0f;
	GameObject battleController;
	
	void Awake()
	{
		battleController = GameObject.FindGameObjectWithTag(Tags.battleController);
	}

	void Update()
	{
		if(health <= 0)
		{
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
		battleController.GetComponent<BattleController>().playerUnitList.Remove (gameObject);
		Destroy(gameObject);
	}
}
