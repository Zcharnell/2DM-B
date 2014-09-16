using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LordAI : MonoBehaviour {

	public GameObject gameController;
	public List<GameObject> moveNodes;
	public GameObject curMoveNode;
	public float speed;
	public float step;
	public string action;
	public Vector3 endPosition;

	private int checkDir;
	private int curMoveNodeIndex;
	private Vector3 curMoveNodePosition;
	private int directionX;
	private int directionY;
	//private localScale scale;
	
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		moveNodes = new List<GameObject>();
		//moveNodes = new List<GameObject>();
		//scale = transform.localScale;
		//Debug.Log('GAME CONTROLLER!' + gameController);
		foreach(GameObject moveNode in gameController.GetComponent<MoveNodes>().moveNodes)
		{
			moveNodes.Add(moveNode);
		}
		findMoveNode ();
		speed = 2.0f;
		action = "patrol";
		directionX = 1;
	}
	
	void FixedUpdate()
	{
		if(curMoveNode == null)
		{
			setMoveNodes();
			//newMoveNode();
		}
		step = Time.deltaTime * speed;
		if(action == "patrol")
		{
			checkDirection(curMoveNodePosition.x);
			transform.position = Vector3.MoveTowards(transform.position,curMoveNodePosition,step);
			if(transform.position == curMoveNodePosition)
			{
				newMoveNode();
			}
		}
		else if(action == "follow")
		{
			checkDirection(endPosition.x);
			transform.position = Vector3.MoveTowards(transform.position,endPosition,step);
		}
	}
	
	void newMoveNode()
	{
		if(curMoveNodeIndex == 3)
		{
			curMoveNodeIndex = 0;
			curMoveNode = moveNodes[curMoveNodeIndex];
			curMoveNodePosition = curMoveNode.transform.position;
		}
		else
		{
			curMoveNodeIndex += 1;
			curMoveNode = moveNodes[curMoveNodeIndex];
			curMoveNodePosition = curMoveNode.transform.position;
		}
	}

	void findMoveNode()
	{
		//Debug.Log("Move Node11!");
		//Debug.Log(curMoveNode);
		float dist = 9999.0f;
		GameObject closestNode = null;
		int closestNodeIndex = 0;
		int tempIndex = 0;
		bool moveNodeFound = false;
		foreach(GameObject moveNode in moveNodes)
		{
			float tempDist = Vector3.Distance(transform.position,moveNode.transform.position);
			//Debug.Log("dist " + dist);
			//Debug.Log("Tempdist " + tempDist);
			if(tempDist < dist)
			{
				dist = tempDist;
				closestNode = moveNode;
				closestNodeIndex = tempIndex;
				moveNodeFound = true;
			}
			tempIndex += 1;
		}
		if(moveNodeFound == true)
		{
			//Debug.Log("Move Node22!");
			curMoveNode = closestNode;
			curMoveNodePosition = closestNode.transform.position;
			curMoveNodeIndex = closestNodeIndex;
			//Debug.Log(curMoveNode);
		}


	}
	
	void setMoveNodes()
	{
		gameController = GameObject.FindGameObjectWithTag(Tags.gameController);
		foreach(GameObject moveNode in gameController.GetComponent<MoveNodes>().moveNodes)
		{
			moveNodes.Add(moveNode);
		}
		findMoveNode ();
	}
	
	public void setFollow(GameObject unitToFollow)
	{
		GameObject u = unitToFollow;
		endPosition = u.transform.position;
		action = "follow";
	}
	
	public void endFollow()
	{
		action = "patrol";
		findMoveNode();
	}
	
	void checkDirection(float endPosX)
	{
		checkDir = directionX;
		if(endPosX > transform.position.x)
		{
			checkDir = -1;
		}
		else if(endPosX < transform.position.x)
		{
			checkDir = 1;
		}
		
		if(checkDir != directionX)
		{
			directionX = checkDir;
			Vector3 tempPos = transform.position;
			Vector3 tempScale = transform.localScale;
			tempScale.x *= -1;
			transform.localScale = tempScale;
			if(directionX == 1)
			{
				tempPos.x -= 1;
				transform.position = tempPos;
			}
			else if(directionX == -1)
			{
				tempPos.x += 1;
				transform.position = tempPos;
			}
		}
	}
}
