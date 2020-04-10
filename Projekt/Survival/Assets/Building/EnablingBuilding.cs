using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingBuilding : Building
{

    [SerializeField]
    GameObject go;

    public override void Build()
    {
        go.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
