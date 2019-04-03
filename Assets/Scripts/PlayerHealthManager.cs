using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
    
	public int playerMaxHealth;

	public int playerCurrentHealth;

	// Start is called before the first frame update
    void Start() {
        //starts game with full health for player
		playerCurrentHealth = playerMaxHealth;

    }

    // Update is called once per frame
    void Update() {
		//deactivates player when health runs out
		if(playerCurrentHealth <= 0) {
			gameObject.SetActive(false);
		}
    }

	//new fuction called by other script
	//how damage is dealt to player
	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;
	}

	//confirms playerMaxHealth int
	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}

}
