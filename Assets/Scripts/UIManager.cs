using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
	//HP bar
	public Slider healthBar;

	//readable player HP
	public Text HPText;

	//controls player health
	public PlayerHealthManager playerHealth;

	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		//connects player health to UI
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		//retrieves health from text 
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
    }

}
