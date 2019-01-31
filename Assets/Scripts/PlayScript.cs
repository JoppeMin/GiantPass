using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {

    public Text bossKills;
    public int bossKillsAmount = 0;

    public void Update()
    {
        bossKills.text = ("" + bossKillsAmount);
    }

	public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
