using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGUI : MonoBehaviour {
	[Header("Setup StartMenu")]
	public GameObject StartMenu;

	[Header("Setup GameOver")]
	public GameObject GameOver;

	[Header("Setup UI")]
	public GameObject UI;
	public Text floor1;
	public Text floor2;
	public Text floor3;
	public Text floor4;

	public static MainGUI instance;

	void Awake(){
		StartMenu.SetActive (true);
		UI.SetActive (true);
		GameOver.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		instance = this;

		floor1.text = "";
		floor2.text = "";
		floor3.text = "";
		floor4.text = "";

		if (GlobalValue.isRestart)
			Play ();
	}

	public void Play(){
		StartMenu.SetActive (false);
		GameManager.instance.Play ();
	}

	//send by FloorController
	public void UpdateFloorNumber(int floor){
		floor1.text = "";
		floor2.text = "";
		floor3.text = "";
		floor4.text = "";
		switch (floor) {
		case 0:
			floor1.text = GameManager.Score + "";
			break;
		case 1:
			floor2.text = GameManager.Score + "";
			break;
		case 2:
			floor3.text = GameManager.Score + "";
			break;
		case 3:
			floor4.text = GameManager.Score + "";
			break;
		default:
			break;
		}
	}

	public void GameOverUI(){
		GameOver.SetActive (true);
	}

	public void Restart(){
		GameManager.instance.Restart (true);
	}

	public void Home(){
		GameManager.instance.Restart (false);
	}

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}
