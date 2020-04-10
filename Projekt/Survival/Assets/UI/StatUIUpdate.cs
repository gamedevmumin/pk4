using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUIUpdate : MonoBehaviour
{
    [SerializeField]
    PlayerStats stats;
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void UpdateHealth()
    {
        text.text = stats.currentHP.ToString();
    }

    public void UpdateHunger()
    {
        text.text = stats.hunger.ToString();
    }


}
