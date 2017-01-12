using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
	public int hScore;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("score", score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void incrementScore() {
		score++;
	}

	public void countScore() {
		InvokeRepeating ("incrementScore", 0.1f, 0.5f);
	}

	public void stopScore() {
		CancelInvoke ("incrementScore");
		PlayerPrefs.SetInt ("score", score);

		if (PlayerPrefs.HasKey ("hScore")) {
			if (score > PlayerPrefs.GetInt ("hScore"))
				PlayerPrefs.SetInt ("hScore", score);
		}
		else PlayerPrefs.SetInt("hScore", score);
	}
}
