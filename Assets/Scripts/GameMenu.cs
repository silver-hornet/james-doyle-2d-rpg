using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;

    CharStats[] playerStats;

    public Text[] nameText;
    public Text[] hpText;
    public Text[] mpText;
    public Text[] lvlText;
    public Text[] expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }
}