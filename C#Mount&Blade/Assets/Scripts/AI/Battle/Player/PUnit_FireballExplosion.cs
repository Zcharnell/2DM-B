using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PUnit_FireballExplosion : MonoBehaviour 
{
	float timer;
	float timer2;
	float fireballTick;
	float fireballLifetime;
	int fireballDamage;
	bool particlesOn;
	ParticleSystem explodeParticles;
	List<Collider2D> targetArray = new List<Collider2D>();

	void Start()
	{
		fireballTick = 0.30f;
		fireballLifetime = 0.10f;
		fireballDamage = 10;
		explodeParticles = GetComponent<ParticleSystem>();
		timer = 0.0f;
		particlesOn = true;
	}

	void Update()
	{
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;

		if(timer2 > fireballTick)
		{
			timer2 = 0.0f;
			DamageInArea();
		}

		if(timer > (fireballLifetime/0.66) && particlesOn)
		{
			particlesOn = false;
			explodeParticles.Stop();
		}
		else if(timer > fireballLifetime)
		{
			Exploded();
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == Tags.unit)
		{
			targetArray.Add (other);
			//Debug.Log ("ARRAY " + targetArray.Count);
			other.GetComponent<UnitHealth>().TakeDamage(fireballDamage);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == Tags.unit)
		{
			targetArray.Remove (other);
		}
	}

	void DamageInArea()
	{
		foreach(Collider2D unit in targetArray)
		{
			if(unit != null)
			{
				unit.GetComponent<UnitHealth>().TakeDamage(fireballDamage);
			}
		}
	}

	void Exploded()
	{
		Destroy(gameObject);
	}
}
