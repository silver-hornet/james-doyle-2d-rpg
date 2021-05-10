﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public BattleType[] potentialBattles;
    public bool activateOnEnter;
    public bool activateOnStay;
    public bool activateOnExit;

    bool inArea;
    public float timeBetweenBattles = 10f;
    float betweenBattleCounter;

    public bool deactivateAfterStarting;

    public bool cannotFlee;

    public bool shouldCompleteQuest;
    public string questToComplete;

    void Start()
    {
        betweenBattleCounter = Random.Range(timeBetweenBattles * 0.5f, timeBetweenBattles * 1.5f);
    }
    void Update()
    {
        if (inArea && PlayerController.instance.canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                betweenBattleCounter -= Time.deltaTime;
            }

            if (betweenBattleCounter <= 0)
            {
                betweenBattleCounter = Random.Range(timeBetweenBattles * 0.5f, timeBetweenBattles * 1.5f);
                StartCoroutine(StartBattleCo());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateOnEnter)
            {
                StartCoroutine(StartBattleCo());
            }
            else
            {
                inArea = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateOnExit)
            {
                StartCoroutine(StartBattleCo());
            }
            else
            {
                inArea = false;
            }
        }
    }

    public IEnumerator StartBattleCo()
    {
        UIFade.instance.FadeToBlack();
        GameManager.instance.battleActive = true;

        int selectedBattle = Random.Range(0, potentialBattles.Length);

        BattleManager.instance.rewardItems = potentialBattles[selectedBattle].rewardItems;
        BattleManager.instance.rewardXP = potentialBattles[selectedBattle].rewardXP;

        yield return new WaitForSeconds(1.5f);

        BattleManager.instance.BattleStart(potentialBattles[selectedBattle].enemies, cannotFlee);
        UIFade.instance.FadeFromBlack();

        if (deactivateAfterStarting)
        {
            gameObject.SetActive(false);
        }

        BattleReward.instance.markQuestComplete = shouldCompleteQuest;
        BattleReward.instance.questToMark = questToComplete;
    }
}
