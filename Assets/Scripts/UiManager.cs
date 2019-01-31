using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public GameObject Boss;
    public GameObject Player;
    
    public Slider hitPoints;
    public Slider chiPoints;
    public Slider bossPoints;

    public Text bossname;
    PlayerMovement playerManager;
    EnemyBehaviour bossManager;

    void Start()
    {
        playerManager = Player.GetComponent<PlayerMovement>();
        bossManager = Boss.GetComponent<EnemyBehaviour>();
        hitPoints.maxValue = playerManager.hitPoints;
        chiPoints.maxValue = playerManager.chiPoints;
        bossPoints.maxValue = bossManager.hitPoints;

    }

    void Update()
    {
        hitPoints.value = playerManager.hitPoints;
        chiPoints.value = playerManager.chiPoints;
        bossPoints.value = bossManager.hitPoints;

        bossname.text = ("Cyclops Wizard - Lvl " + bossManager.level);
    }
}
