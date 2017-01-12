using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	public GameObject titlePanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text hScore1;
	public Text hScore2;

	void Awake() {
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		hScore1.text = "High Score: "+PlayerPrefs.GetInt ("hScore");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GameStart() {
		tapText.SetActive (false);
		titlePanel.GetComponent<Animator> ().Play ("titleUp");
	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt ("score").ToString();
		hScore2.text = PlayerPrefs.GetInt ("hScore").ToString ();
		gameOverPanel.SetActive (true);
	}

	public void Reset() {
		SceneManager.LoadScene (0);
	}
}
