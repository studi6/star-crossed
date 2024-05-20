using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplayHandler : MonoBehaviour
{
    public GameObject heartPrefab;
    List<HeartDisplay> hearts = new List<HeartDisplay>();
    private HealthSystem playerHealth;
    private int numHearts = 4;

    // Caching vars
    private int iPlayerHealth;
    
    private void Awake()
    {
        // Caching
        iPlayerHealth = (int)playerHealth.fHealth;
    }

    void OnEnable()
    {
        //if (SystemManager.instance != null && SystemManager.instance.player != null)
        //{
            drawHearts();
        //}
    }

    void Update()
    {
        updateHearts();
    }

    public void drawHearts()
    {
        clearHearts();

        // draws 4 hearts
        for (int i = 0; i < numHearts; i++)
        {
            createEmptyHeart();
        }

        updateHearts();
    }

    public void updateHearts()
    {
        // fixes having no hearts when 0 < health < 20
        if ((iPlayerHealth < 20) && (iPlayerHealth > 0))
        {
            hearts[1].setHeartImage((HeartStatus)2);
            for (int i = 1; i < hearts.Count; i++)
            {
                int playerHealthEights = (iPlayerHealth / 100) * (numHearts * 2);
                int heartStatusRemainder = (int)Mathf.Clamp(playerHealthEights - (i * 2), 0, 2);
                hearts[i].setHeartImage((HeartStatus)heartStatusRemainder);
            }
            return;
        }

        // draw hearts based on health
        for (int i = 0; i < hearts.Count; i++)
        {
            int playerHealthEights = (iPlayerHealth / 100) * (numHearts * 2);
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealthEights - (i * 2), 0, 2);
            hearts[i].setHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    // clears hearts
    public void clearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HeartDisplay>();
    }

    public void createEmptyHeart()
    {
        GameObject heart = Instantiate(heartPrefab);
        heart.transform.SetParent(transform);

        HeartDisplay heartComponent = heart.GetComponent<HeartDisplay>();
        heartComponent.setHeartImage(HeartStatus.EMPTY);
        hearts.Add(heartComponent);
    }
}
