using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{

    [HideInInspector]
    public int currentHP;
    [SerializeField]
    public int maxHP;
    [SerializeField]
    public int hunger;
    [SerializeField]
    public int maxHunger;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpHeight;
    [SerializeField]
    public float invincibilityTime;

    [SerializeField]
    public bool upgraded = false;

    private void OnEnable()
    {
        currentHP = maxHP;
        hunger = maxHunger;
        upgraded = false;
        speed = 100;
    }

    public void Set(PlayerStats stats)
    {

        currentHP = stats.currentHP;
        maxHP = stats.maxHP;
        speed = stats.speed;
        jumpHeight = stats.jumpHeight;
        invincibilityTime = stats.invincibilityTime;
    }
}