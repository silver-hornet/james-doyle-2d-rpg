﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public float waitToLoad;

    void Update()
    {
        if (waitToLoad > 0)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("Current_Scene"));
                GameManager.instance.LoadData();
                QuestManager.instance.LoadQuestData();
            }    
        }
    }
}
