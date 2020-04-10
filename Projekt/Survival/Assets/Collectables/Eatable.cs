using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Eatable : Item
{
    [SerializeField]
    int hungerRestore;

    [SerializeField]
    GameEvent statsChange;
    [SerializeField]
    GameEvent eqChange;

    public override void Use()
    {
        AudioManager.instance.PlaySound("Eating");
        stats.hunger += hungerRestore;
        if (stats.hunger >= 100) stats.hunger = 100;
            Amount -= 1;
        statsChange.Raise();
        eqChange.Raise();

    }


}
