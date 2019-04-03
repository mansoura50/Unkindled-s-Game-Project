using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    
	//amount of damage a certain enemy deals
	public int damageToGive; 

	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

	void OnCollisionEnter2D (Collision2D other) {
		//player death replaced by script in PlayerHealthManager

		if(other.gameObject.name == "Player") {
			//Player gets damaged when touching any gameObject labelled "Enemy"
			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
		}
	}

}
