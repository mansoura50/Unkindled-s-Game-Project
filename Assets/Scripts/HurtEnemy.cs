using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	//weapon damage
	public int damageToGive;

	//enemy damage particles
	public GameObject damageBurst;

	//to set enemy damage particles located at sword tip
	public Transform hitPoint;

	//creates damage number from FloatingNumbers
	public GameObject damageNumber;
    
	// Start is called before the first frame update
    void Start()  {
        
    }

    // Update is called once per frame
    void Update() {

    }

	//2D box collider attached to sword
	void OnTriggerEnter2D(Collider2D other) {
		//allows all enemies to be damaged if catergorized as "Enemy"
		if(other.gameObject.tag == "Enemy") {
			//Destroy(other.gameObject); --for instant enemy death
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			//shows damage particles
			Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
			//Quaternion controls x,y,z positions based on sword direction
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
		}
	}

}
