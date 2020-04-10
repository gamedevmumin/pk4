using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    Animator anim;
    [SerializeField]
    PlayerStats stats;
    [SerializeField]
    float delay = 0.5f;
    float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Upgraded", stats.upgraded);
        if (timer <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Slash");
                AudioManager.instance.PlaySound("Swoosh");
                timer = delay;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(10);
        }
        else
        {
            ResourceBank resourceBank = collision.GetComponent<ResourceBank>();
            if (resourceBank)
            {
                resourceBank.Damage(25);
            }
        }
        
    }
}
