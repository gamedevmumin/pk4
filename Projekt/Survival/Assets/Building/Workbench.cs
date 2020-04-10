using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : Building
{
    SpriteRenderer sR;
    [SerializeField]
    GameObject canvas;
    public override void Build()
    {
        sR.enabled = true;
        canvas.SetActive(true);
        GetComponent<Highlight>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    { 
        sR = GetComponent<SpriteRenderer>();
        GetComponent<Highlight>().enabled = false;
        sR.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
