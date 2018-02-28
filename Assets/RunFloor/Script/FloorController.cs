using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {
	public static FloorController instance;
	public Floor[] Floors;
	[Header("Trap Setup: set trap easy to hard")]
	public GameObject[] Traps;
	[Header("BackGround Setup: change color randomly")]
	public SpriteRenderer BackGround;
	public Color[] BackGroundColor;

	private int currentFloor = 100;

	public static GameObject[] GetTraps {
		get{ return instance.Traps; }
	}

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}

	public void CreateTrap(){
		int random = Random.Range (0, Floors.Length);
		if (random == currentFloor) {
			CreateTrap ();
			return;
		}
		//Change BackGround Color
		if (BackGroundColor.Length > 0)
			BackGround.color = BackGroundColor [Random.Range (0, BackGroundColor.Length)];

		currentFloor = random;
		Floors [currentFloor].CreateTrap ();
		MainGUI.instance.UpdateFloorNumber (random);
	}
}
