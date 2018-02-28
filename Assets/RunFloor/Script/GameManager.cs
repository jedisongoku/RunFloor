using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public enum GameState
	{
		Menu, Playing, Pause, Fail
	}
	public GameState state;

	public float speedPlayer = 5f;
	public float limitedSpeed = 6f;
	public int increaseSpeedAfter = 5;
	public float increaseStep = 0.15f;

	private int score = 1;
	private int increaseSpeedAfter_ = 0;

	public static int Score{
		get{ return instance.score; }
		set{ instance.score = value; }
	}

	public static int Best {
		get{ return PlayerPrefs.GetInt ("best", 0); }
		set{ PlayerPrefs.SetInt ("best", value); }
	}

	public static float Speed{
		get{ return instance.speedPlayer; }
		set{ instance.speedPlayer = value; }
	}

	public static GameState CurrentState{
		get{ return instance.state; }
		set{ instance.state = value; }
	}

	// Use this for initialization
	void Start () {
		instance = this;
		state = GameState.Menu;
		increaseSpeedAfter_ = increaseSpeedAfter;
//		AdsController.HideAds ();
	}

	void Update(){
		if (score >= increaseSpeedAfter_ && speedPlayer<limitedSpeed) {
			increaseSpeedAfter_ += increaseSpeedAfter;
			speedPlayer += increaseStep;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
	
	public void Play(){
		state = GameState.Playing;
		FloorController.instance.CreateTrap ();
	}

	public void Restart(bool isRestart){
		GlobalValue.isRestart = isRestart;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void GameOver(){
		if (score > Best)
			Best = score;
		StartCoroutine (ShowGameOverDelay (1.5f));
        AppsFlyerMMP.Score(score);
        GoogleManager.ReportScore();
//		AdsController.ShowAds ();
	}

	IEnumerator ShowGameOverDelay(float time){
		yield return new WaitForSeconds (time);
		MainGUI.instance.GameOverUI ();
	}
}
