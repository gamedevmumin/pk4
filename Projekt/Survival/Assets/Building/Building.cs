using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected bool isBuilt = false;

    public abstract void Build();
}
