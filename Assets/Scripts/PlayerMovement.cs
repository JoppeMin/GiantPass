using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject mouseRender;

    public AudioClip Whoosh, HealSound;
    static AudioSource audioSrc;

    Vector2 position;
    Vector2 mousePos;
    public float replenishSpeed;
    public float hitPoints;
    public float chiPoints; 

    BoxCollider2D boxCollider;


    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        position = transform.position;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseVisual();
        actionSlice();
        characterMovement();
        deathCheck();
        replenishChi();
        actionHeal();
    }
    void replenishChi()
    {
        if (chiPoints < 100)
        {
            chiPoints += replenishSpeed;
        }
    }
    void characterMovement()
    {
        transform.position = Vector2.Lerp(transform.position, mousePos, 5 * Time.deltaTime);
    }
    void mouseVisual()
    {
        mouseRender.transform.position = mousePos;
    }
    void deathCheck()
    {
        if (hitPoints < 0)
        {
            SceneManager.LoadScene(0);
            print("IK BEN DOOD");
        }
    }

    void actionSlice()
    {
        if (Input.GetButtonDown("Fire1") && chiPoints > 25)
        {
            chiPoints -= 25;

            gameObject.GetComponent<Animator>().SetBool("Hitting", true);
            audioSrc.PlayOneShot(Whoosh);
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("Hitting", false);
        }
    }
    void actionHeal()
    {
        if (hitPoints > 100)
        {
            hitPoints = 100;
        }
        if (Input.GetButtonDown("Fire2") && chiPoints > 25)
        {
            gameObject.GetComponent<Animator>().SetBool("Healing", true);
            chiPoints -= 25;
            hitPoints += 25;
            audioSrc.PlayOneShot(HealSound);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Healing", false);
        }
    }
}
