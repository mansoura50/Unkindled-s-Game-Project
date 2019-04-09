using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//player speed
	public float moveSpeed;

	//identifies animator
	private Animator anim; 

	private Rigidbody2D myRigidbody;

	private bool playerMoving; 
	//has x and y value
	private Vector2 lastMove;

	//determines if player is attacking or not
	private bool attacking;
	//attack speed
	public float attackTime;
	private float attackTimeCounter;

    
	// Start is called before the first frame update
    void Start() {
		anim = GetComponent <Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

		//when player is idle
		playerMoving = false;

		//!attacking means when not attacking movement is allowed
		if(!attacking) {


		//move the character left or right
		// || represents "or"
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f ) {

			//transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"), 0f); 

		}

		//move the character up or down
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f ) {

			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw("Vertical")); 

		}

		//stops player from moving non-stop when directional key is used once
		if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) {
			myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y); 
		}

		if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f) {
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f); 
		}

		//attack anim plays when pressing "E"
		if (Input.GetKeyDown(KeyCode.E)) {
			attackTimeCounter = attackTime;
			attacking = true;
			//stops player movement when attacking
			myRigidbody.velocity = Vector2.zero;
			anim.SetBool("Attack", true);
		}

		}//from if(!attacking)

		if(attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}

		//ends attack anim
		if(attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool("Attack", false);
		}
			

		//gets float parametars from the animator
		//directional animations 
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool("PlayerMoving",playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);

    }
}
