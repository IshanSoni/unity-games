using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public GameObject particle;

	[SerializeField]
	public float speed;

	Rigidbody rb;
	bool started;
	bool gameOver;

	void Awake() {
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Input.GetMouseButtonDown (0) && !gameOver) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				GameManager.instance.StartGame ();
			}
		}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
			rb.velocity = new Vector3 (0, -25f, 0);

			Camera.main.GetComponent<CameraFollow> ().gameOver = true;

			GameManager.instance.GameOver ();
		}

		if (Input.GetMouseButtonDown (0))
			SwitchDirection();
	}

	void SwitchDirection() {
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Bonus") {
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
		}
	}
}
