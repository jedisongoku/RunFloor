using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	public GameObject player;
	public GameObject cover;

	private GameObject[] traps;
	private float yPos;
	private float[] xPos = { -4.7f, 4.7f };
	private GameObject trap;
	// Use this for initialization
	void Start () {
		traps = FloorController.GetTraps;
		cover.SetActive (true);
		yPos = transform.position.y + 0.3f;
	}


	public void CreateTrap(){
		int randomMax = traps.Length;
		if (GameManager.Score < 5) {
			randomMax = 5;		//first 5 easy trap
		}
		cover.SetActive (false);
		trap = Instantiate (traps [Random.Range (0, randomMax)], transform.position, Quaternion.identity) as GameObject;
		Instantiate (player, new Vector3(xPos[Random.Range (0, xPos.Length)],yPos,0), Quaternion.identity);
	}

	public void Pass(){
		cover.SetActive (true);
		Destroy (trap);
		FloorController.instance.CreateTrap ();
	}
}
