using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour {
	public string FaceBookLink = "Your facebook link";
	public Image SoundImg;
	public Sprite soundON;
	public Sprite soundOFF;
	public Text best;

	void Start(){
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

	public void Facebook(){
		Application.OpenURL (FaceBookLink);
	}
}
