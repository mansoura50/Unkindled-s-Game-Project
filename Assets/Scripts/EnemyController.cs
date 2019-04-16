using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	
	public float moveSpeed;//speed
	private Rigidbody2D myRigidbody;//physics and collisions
	private bool isMoving;//boolean, determines if enemy is moving
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;
	
	
	void Start(){
		myRigidbody = GetComponent<Rigidbody2D>();
		
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove*0.75f, timeToMove*1.25f);
		
		
	}
	
	
	void Update(){
		
		if (isMoving)
		{
			timeToMoveCounter-=Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			if(timeToMoveCounter<0f){
				isMoving = false;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
				myRigidbody.velocity = Vector2.zero;
			}
		}
		else{
			timeBetweenMoveCounter-= Time.deltaTime;
			if(timeBetweenMoveCounter<0f){
				isMoving=true;
				timeToMoveCounter = Random.Range(timeToMove*0.75f, timeToMove*1.25f);
				moveDirection= new Vector3(Random.Range(-1f,1f) *moveSpeed,Random.Range(-1,1f)*moveSpeed,0f);
			}
				
		}
		
		
		
		
		if(reloading) {
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0) {
				Application.LoadLevel(Application.loadedLevel);
				thePlayer.SetActive(true);
			}
		}
		
		
	}
//exclued onCollision2D due to player health manager, followed the tutorial otherwize, hope this works.










}