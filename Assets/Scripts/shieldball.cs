using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldball : MonoBehaviour {
    public GameObject fireballPrefab;

    Vector3 position;
    public Vector2 velocity;
    private float lifetime;
    public float damage;

    void Start () {
        position = transform.position;
	}
	
	void Update () {
        transform.position = position;

        position += (Vector3) velocity;
        lifetime++;

        if (lifetime * Time.deltaTime > 5)
        {
            Destroy(this.gameObject);
        }

	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.tag)
        {

            case "PlayerCharacter":
                coll.GetComponentInParent<PlayerMovement>().hitPoints -= damage;
                Destroy(this.gameObject);
                break;
        }
    }
}
