using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building
{

    [SerializeField]
    List<Sprite> sprites;
    public static int phase = -1;

    SpriteRenderer sR;

    public override void Build()
    {
        phase++;
        sR.sprite = sprites[phase];

    }

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
