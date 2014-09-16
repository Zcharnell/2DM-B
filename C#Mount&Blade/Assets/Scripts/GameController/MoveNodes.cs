using UnityEngine;
using System.Collections;

public class MoveNodes : MonoBehaviour 
{
	public GameObject[] moveNodes;
	
	void Start () {
		Reset();
	}
	
	void Update () {
		
	}
	
	int sortNodes(GameObject g1,GameObject g2)
	{
		int compare = string.Compare(g1.name,g2.name);
		return compare;
	}
	
	public void Reset()
	{
		System.Array.Clear(moveNodes,0,moveNodes.Length);
		moveNodes = GameObject.FindGameObjectsWithTag(Tags.moveNode);
		Debug.Log("1: " + moveNodes);
		//moveNodes.Sort(sortNodes);
		Debug.Log("2: " + moveNodes);
	}
}
