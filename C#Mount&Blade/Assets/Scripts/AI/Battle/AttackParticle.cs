using UnityEngine;
using System.Collections;

public class AttackParticle : MonoBehaviour 
{
	float timer;

	void Awake()
	{
		timer = 0.0f;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer > 0.5f)
		{
			Destroy(gameObject);
		}
	}
}
