using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<ParticleSystem>().Stop();
        gameObject.GetComponent<ParticleSystem>().randomSeed = 123;
        gameObject.GetComponent<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
