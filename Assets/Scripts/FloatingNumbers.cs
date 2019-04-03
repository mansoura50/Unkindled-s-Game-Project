using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {

	//how fast damage indicaters appear
	public float moveSpeed;

	//how much damage an enemy does
	public int damageNumber;

	//part of UI
	public Text displayNumber;

   
	// Start is called before the first frame update
	void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		//applies changes based on damage amount
		displayNumber.text = "" + damageNumber;
		//speed that number is shown
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }  

}
