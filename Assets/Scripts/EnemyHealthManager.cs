using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    
	public int MaxHealth;

	public int CurrentHealth;

	// Start is called before the first frame update
	void Start() {
		//starts game with full health for enemy
		CurrentHealth = MaxHealth;

	}

	// Update is called once per frame
	void Update() {
		//deletes enemy when health runs out
		if(CurrentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	//new fuction called by other script
	//how damage is dealt to enemy
	public void HurtEnemy(int damageToGive) {
		CurrentHealth -= damageToGive;
	}

	//confirms MaxHealth int
	public void SetMaxHealth() {
		CurrentHealth = MaxHealth;
	}

}
