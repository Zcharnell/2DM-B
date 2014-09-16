using UnityEngine;
using System.Collections;

public class BattleCollisionTrigger : MonoBehaviour 
{
	public GameObject gameController;
	private MouseListener mouseListener;
	private MoveNodes moveNodes;
	
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		mouseListener = gameController.GetComponent<MouseListener>();
		moveNodes = gameController.GetComponent<MoveNodes>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Entered!");
		if(other.tag == Tags.lord)
		{
			mouseListener.stuff += 5;
			Debug.Log(mouseListener.stuff);
			Application.LoadLevel("battlemap");
			mouseListener.stuff += 5;
			Debug.Log(mouseListener.stuff);
			moveNodes.Reset();
			//gameController.GetComponent(SpawnScript).Reset();
		}
	}
}
