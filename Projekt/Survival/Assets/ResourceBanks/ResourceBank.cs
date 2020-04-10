using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank : MonoBehaviour
{
    [SerializeField]
    bool upgradeRequired = false;
    [SerializeField]
    Collectable collectable;
    [SerializeField]
    int minAmount = 2;
    [SerializeField]
    int maxAmount = 5;
    [SerializeField]
    Transform spawnPosition;
    [SerializeField]
    string destructionSound;

    [SerializeField]
    Sprite damaged;
    [SerializeField]
    Sprite reallyDamaged;

    bool isPlayerInRange = false;
    [SerializeField]
    int maxDurability = 100;
    int durability;

    [SerializeField]
    PlayerStats stats;

    CameraShake cS;

    SpriteRenderer sR;
    BlinkEffect blinkEffect;
    private void Start()
    {
        durability = maxDurability;
        sR = GetComponent<SpriteRenderer>();
        cS = GameObject.Find("CameraShake").GetComponent<CameraShake>();
        blinkEffect = GetComponent<BlinkEffect>();
    }

    void Update()
    {
        
    }

    private void Destroy()
    {
        int amount = Random.Range(minAmount, maxAmount);

        for (int i = 0; i < amount; i++)
        {
            Rigidbody2D rb = Instantiate(collectable.gameObject, spawnPosition.position, Quaternion.Euler(Vector3.zero)).GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-3f, 3f) * 1
                , Random.Range(0f, 3f) * 1), ForceMode2D.Impulse);
        }
        AudioManager.instance.PlaySound(destructionSound);
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        bool canDamage = false;
        if (stats.upgraded) canDamage = true;
        if (!upgradeRequired) canDamage = true;
        if (canDamage)
        {
            AudioManager.instance.PlaySound("StoneHit");
            durability -= damage;
            cS.Shake(0.03f, 0.025f);
            StartCoroutine(blinkEffect.PlayEffect(sR));
            if (durability <= 0 * maxDurability)
            {
                Destroy();

            }
            else if (reallyDamaged && durability <= 0.25 * maxDurability)
            {
                sR.sprite = reallyDamaged;

            }
            else if (damaged && durability <= 0.5 * maxDurability)
            {
                sR.sprite = damaged;

            }
        }
        else
        {
            AudioManager.instance.PlaySound("StoneHit2");
            StartCoroutine(blinkEffect.PlayEffect(sR));
            cS.Shake(0.03f, 0.025f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //isPlayerInRange = false;
    }
}
