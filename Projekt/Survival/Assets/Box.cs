using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Building
{

    [SerializeField]
    BoxCollider2D box;

    public override void Build()
    {
        box.enabled = false;
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
