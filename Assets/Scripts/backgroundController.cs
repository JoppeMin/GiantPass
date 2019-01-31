using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour {

    Material material;
    Vector2 offsetVector;
    public float offset;

	void Start () {
        material = GetComponent<Renderer>().material;
    }
	
	void Update () {
        material.mainTextureOffset -= offsetVector;
        offsetVector.y = offset * Time.deltaTime;
	}
}
