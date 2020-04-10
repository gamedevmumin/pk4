using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crown : Building
{
    [SerializeField]
    PlayerStats stats;
    [SerializeField]
    Text text;
    [SerializeField]
    Image image;
    public override void Build()
    {
        stats.upgraded = true;
        text.text = "UPGRADED";
        image.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
