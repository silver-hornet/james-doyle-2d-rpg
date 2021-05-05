﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public Text damageText;

    public float lifetime = 1f;
    public float moveSpeed = 1f;

    public float placementJitter = 0.5f;

    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    public void SetDamage(int damageAmount)
    {
        damageText.text = damageAmount.ToString();
        transform.position += new Vector3(Random.Range(-placementJitter, placementJitter), Random.Range(-placementJitter, placementJitter), 0f);
    }
}
