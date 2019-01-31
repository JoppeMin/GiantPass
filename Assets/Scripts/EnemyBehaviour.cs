using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject fireballPrefab;
    public GameObject shieldballPrefab;
    public GameObject deflectHit;
    public GameObject mouth;

    public GameObject player;
    public Vector2 playerDir;

    public int numberOfProjectiles;
    public float projectileSpeed;
    private const float radius = 1f; //sine angle

    public float hitPoints;
    public float level;

    Animator animator;
    PlayScript playScript;

    public AudioClip BossHit;
    static AudioSource audioSrc;

    void Start () {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playScript = GetComponent<PlayScript>();
    }
	
	void Update () {
        Death();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.tag)
        {
            case "DeflectFireball":
                Instantiate(deflectHit, coll.gameObject.transform);
                Destroy(coll.gameObject);
                hitPoints -= 5;
                audioSrc.PlayOneShot(BossHit);
                break;
        }
    }
    void Death()
    {
        if (hitPoints <= 0)
        {
            animator.Play("Death");
            level++;
            hitPoints = 100 * (1 +(level * 0.1f));
            playScript.bossKillsAmount = (int) level;
            audioSrc.PlayOneShot(BossHit);
        }
    }
    // Aangeroepen in animation
    void PatternRadial(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles-1; i++)
        {
            float projectileDirXPosition = mouth.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = mouth.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - (Vector2)mouth.transform.position).normalized * projectileSpeed;

            GameObject fireballObj = Instantiate(fireballPrefab, mouth.transform.position, Quaternion.identity);
            fireballObj.GetComponent<fireball>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            fireballObj.GetComponent<fireball>().damage = 10 * (1 + (level * 0.5f));

            angle += angleStep;
        }
    }
    void PatternRadialShield(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = mouth.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = mouth.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - (Vector2)mouth.transform.position).normalized * projectileSpeed;

            GameObject fireballObj = Instantiate(shieldballPrefab, mouth.transform.position, Quaternion.identity);
            fireballObj.GetComponent<shieldball>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            fireballObj.GetComponent<shieldball>().damage = 20 * (1 + (level * 0.5f));

            angle += angleStep;
        }
    }
    void PatternShootTowards()
    {
        playerDir = (player.transform.position - mouth.transform.position).normalized;
        GameObject fireballObj = Instantiate(fireballPrefab, mouth.transform.position, Quaternion.identity);
        fireballObj.GetComponent<fireball>().velocity = playerDir;
        fireballObj.GetComponent<fireball>().damage = 10 * (1 + (level * 0.5f));
    }
    void PatternShootShieldTowards()
    {
        playerDir = (player.transform.position - mouth.transform.position).normalized;
        GameObject fireballObj = Instantiate(shieldballPrefab, mouth.transform.position, Quaternion.identity);
        fireballObj.GetComponent<shieldball>().velocity = playerDir;
        fireballObj.GetComponent<fireball>().damage = 20 * (1 + (level * 0.5f));
    }
}
