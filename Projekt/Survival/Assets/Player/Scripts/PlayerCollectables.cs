using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerCollectables : ScriptableObject
{
    [SerializeField]
    public Dictionary<string, Item> items = new Dictionary<string, Item>();

    private void OnEnable()
    {
        items = new Dictionary<string, Item>();
    }

    public void Collect(Item item)
    {
        AudioManager.instance.PlaySound("Collection");
        int amount;
        if (items.ContainsKey(item.Type))
        {
            amount = ++items[item.Type].Amount;
            Debug.Log("You've got " + amount + " " + item.Type);
        }
        else
        {
            items[item.Type] = item;
            items[item.Type].Amount = 1;
        }

    }
}
