using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Building
{
    [SerializeField]
    Sprite firstPhase;
    [SerializeField]
    Sprite secondPhase;
    [SerializeField]
    Sprite thirdPhase;
    SpriteRenderer sR;

    [SerializeField]
    float growthTime = 300f;
    [SerializeField]
    float timer = 0f;
    public override void Build()
    {
        isBuilt = true;
        sR.sprite = firstPhase;
    }

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       if(isBuilt && sR.sprite != thirdPhase)
        {
            if( timer >= growthTime && sR.sprite == firstPhase)
            {
                sR.sprite = secondPhase;
                timer = 0f;
                AudioManager.instance.PlaySound("Plant");
            }
            else if (timer >= growthTime && sR.sprite == secondPhase)
            {
                sR.sprite = thirdPhase;
                timer = 0f;
                AudioManager.instance.PlaySound("Plant");
                Regrowth.treesAmount += 1;  
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }


}
