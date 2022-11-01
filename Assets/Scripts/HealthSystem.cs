using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public GameObject heartPrefab;
    public GameManager health;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void Start()
    {
        gameObject.SetActive(true); z
        CreateHearts();
    }


    public void EmptyHeart()
    {
        //Cloning new heart 
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        //Sets heart to empty and adds to list
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHearts(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void CreateHearts()
    {
        ClearHearts();

        //Calculates how many hearts we need to make
        //Eg: MaxHealth is 6 so it creates 6 half or 3 full hearts
        float maxHealthRemainder = GameManager.MaxHealth % 2;
        int heartsNeeded = (int)(GameManager.MaxHealth / 2 + maxHealthRemainder);
        for(int i = 0; i < heartsNeeded; i++)
        {
            EmptyHeart(); // Creates hearts
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(GameManager.Health - (i * 2), 0, 2);
            hearts[i].SetHearts((HeartStatus)heartStatusRemainder);
        }
    }

    private GameObject Instatiate(GameObject heartPrefab)
    {
        throw new NotImplementedException();
    }

    public void ClearHearts() //Destroys all the children of Hearts
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }


    //When player is damaged it invokes OnPlayerDamaged and 
    private void OnEnable()
    {
        GameManager.OnPlayerDamaged += CreateHearts;
    }

    private void OnDisable()
    {
       
    }
}