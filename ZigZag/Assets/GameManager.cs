using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver;

	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		UIManager.instance.GameStart ();
		ScoreManager.instance.countScore ();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().startSpawningPlats ();
	}

	public void GameOver() {
		gameOver = true;
		ScoreManager.instance.stopScore ();
		UIManager.instance.GameOver ();
	}
}
