using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
    
	//how long damage indicator is shown before being removed
	public float timeToDestroy;

	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
		timeToDestroy -= Time.deltaTime;

		if(timeToDestroy <= 0) {
			Destroy (gameObject);
		}
    }

}
