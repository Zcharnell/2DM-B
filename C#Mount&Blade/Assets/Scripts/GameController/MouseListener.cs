using UnityEngine;
using System.Collections;

public class MouseListener : MonoBehaviour 
{
	public int stuff = 0;
	private bool levelLoading;
	
	void Awake () {
		DontDestroyOnLoad(this);
		//stuff = 1;
	}
	
	void Start()
	{
		//GameObject.FindGameObjectWithTag(Tags.lord).GetComponent<LordAI>().enabled = true;
	}
	
	void Update () {
		if(Application.loadedLevel == 0)
		{
			Debug.Log("LOADED LEVEL: " + Application.loadedLevel);
			levelLoading = true;
			Application.LoadLevel("testscene");
		}
		else if(Application.loadedLevel == 2)
		{
			if(Input.GetKeyDown(KeyCode.B))
			{
				this.GetComponent<MouseListener>().stuff += 5;
				levelLoading = true;
				Application.LoadLevel("testscene");
			}
		}
		if(levelLoading)
		{
			Debug.Log("LEVEL LOADING!!");
			if(Application.loadedLevel == 1)
			{
				Debug.Log("LOADED LEVEL: " + Application.loadedLevel);
				levelLoading = false;
				this.GetComponent<MoveNodes>().Reset();
				//this.GetComponent<SpawnScript>().Reset();
				Debug.Log("PARENT " + this.tag);
				GameObject.FindGameObjectWithTag(Tags.lord).GetComponent<LordAI>().enabled = true;
			}
		}
		if(Input.GetKeyDown(KeyCode.V))
		{
			this.GetComponent<MoveNodes>().Reset();
			//this.GetComponent<SpawnScript>().Reset();
			Debug.Log("PARENT " + this.tag);
			GameObject[] lordArray = GameObject.FindGameObjectsWithTag(Tags.lord);
			foreach(GameObject i in lordArray)
			{
				i.GetComponent<LordAI>().enabled = true;
			}
		}
	}
}
