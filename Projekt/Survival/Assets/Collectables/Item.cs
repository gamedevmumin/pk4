using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Type { get { return type; } protected set { type = value; } }
    public int Amount {  get { return amount;  } set { amount = value; } }

    public Sprite Icon { get { return icon; } set { icon = value; } }

    public bool Usable;

    [SerializeField]
    protected PlayerStats stats;

    private void OnEnable()
    {
        Amount = 0;
    }

    public virtual void Use()
    {
        Debug.Log("Using item");
    }

    [SerializeField]
    protected string type;
    [SerializeField]
    protected int amount;
    [SerializeField]
    protected Sprite icon;

}
