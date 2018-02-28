using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Image SoundImg;
	public Sprite soundON;
	public Sprite soundOFF;
	public Text score;
	public Text best;

	void Start(){
		score.text = GameManager.Score + "";
		best.text = "BEST: "+ GameManager.Best;

		//setup audio state
		if (GlobalValue.isSound) {
			SoundImg.sprite = soundON;
		} else {
			SoundImg.sprite = soundOFF;
		}
	}

	public void Audio(){
		GlobalValue.isSound = !GlobalValue.isSound;
		if (!GlobalValue.isSound) {
			AudioListener.volume = 0;
			SoundImg.sprite = soundOFF;
		} else {
			AudioListener.volume = 1;
			SoundImg.sprite = soundON;
			SoundManager.PlaySfx ("Click");
		}

	}

	public void Home(){
		GlobalValue.isRestart = false;
		MainGUI.instance.Home ();
	}
}
