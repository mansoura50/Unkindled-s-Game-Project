using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

	//slime move speed
	public float moveSpeed;

	//enemies rigidbody/hitbox stuff
	private Rigidbody2D myRigidbody;

	//if the slime moving or not
	private bool moving;

	//how long between movements
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	//how long to move 
	public float timeToMove;
	private float timeToMoveCounter;

	//direction of movements
	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

    // Start is called before the first frame update
    void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();

		//input movements,speed and direction of slime
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		//random movement,speed and direction of slime
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);


    }

    // Update is called once per frame
    void Update() {
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0) {
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

			}

		}


		else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0) {
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				//moves left, right, up, down
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed , 0f);
			}
		}

		//how game reloads after player death
		if(reloading) {
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0) {
				Application.LoadLevel(Application.loadedLevel);
				thePlayer.SetActive(true);
			}
		}

    }


	//how enemies deal damage (touching)
	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.name == "Player") {
			//Destroy (other.gameObject);

			//hit players can't move, respawns/reloads level
			other.gameObject.SetActive(false);
			reloading = true;
			//allows player to be reloaded with level 
			thePlayer = other.gameObject;
		}
	}

}
