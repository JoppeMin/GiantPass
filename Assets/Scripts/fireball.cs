using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    public GameObject deflectedFireball;
    Vector3 position;
    public Vector2 velocity;
    private float lifetime;
    public float damage;

    public AudioClip PlayerHit, BallHit;
    static AudioSource audioSrc;

    void Start () {
        audioSrc = GetComponent<AudioSource>();
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
            case "Slash":
                audioSrc.PlayOneShot(BallHit);
                Destroy(this.gameObject);
                Instantiate(deflectedFireball, transform.position, new Quaternion(0, 0, 0, 0));
                break; 

            case "PlayerCharacter":
                coll.GetComponentInParent<PlayerMovement>().hitPoints -= damage;
                audioSrc.PlayOneShot(PlayerHit);
                Destroy(this.gameObject);
                break;
        }
    }
}
