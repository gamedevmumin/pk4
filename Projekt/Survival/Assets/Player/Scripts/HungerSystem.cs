using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    [SerializeField]
    float timeToLoseWeight;
    float timerToLoseWeight;
    [SerializeField]
    GameEvent statChange;

    [SerializeField]
    int weightLose;

    [SerializeField]
    PlayerStats stats;

    [SerializeField]
    PlayerController pC;

    float timerToLoseHP = 3f;

    // Start is called before the first frame update
    void Start()
    {
        timerToLoseWeight = timeToLoseWeight;
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stats.hunger <= 0)
        {
            if (timerToLoseHP <= 0f)
            {
                Debug.Log("XD");
                pC.TakeDamage(5);
                timerToLoseHP = 3f;
            }
            else timerToLoseHP -= Time.deltaTime;
        }
        if (timerToLoseWeight<=0f)
        {
            timerToLoseWeight = timeToLoseWeight;
            stats.hunger -= weightLose;
            if(stats.hunger <= 0f) stats.hunger = 0;
            statChange.Raise();
        }
        else
        {
            timerToLoseWeight -= Time.deltaTime;
        }

       
    }
}
