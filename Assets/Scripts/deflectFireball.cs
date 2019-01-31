using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deflectFireball : MonoBehaviour {

    Vector2 position;
    public GameObject oni;
    public Vector2 velocity;
    private float lifetime;
    Vector2 targetPosition;


    void Start () {
        position = transform.position;
        velocity = (oni.transform.position - transform.position).normalized;
    }
	
	void Update () {
        transform.position = position;

        position += (velocity)*2;

        lifetime++;

        if (lifetime * Time.deltaTime > 2)
        {
            Destroy(this.gameObject);
        }
    }
}
