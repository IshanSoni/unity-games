using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public bool gameOver;
	public GameObject platform;
	public GameObject bonus;
	Vector3 lastPos;
	float size;

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;
		for (int i = 0; i < 30; i++)
			spawnPlat ();
	}

	public void startSpawningPlats() {
		InvokeRepeating ("spawnPlat", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver)
			CancelInvoke();
	}

	void spawnPlat() {
		int rand = Random.Range (0, 8);
		if (rand < 4)
			spawnX ();
		else if(rand >= 4)
			spawnZ ();
		if (rand == 2 || rand == 5)
			Instantiate (bonus, new Vector3(lastPos.x, lastPos.y+1, lastPos.z), bonus.transform.rotation);
	}

	void spawnX() {
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
	}

	void spawnZ() {
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
	}
}
