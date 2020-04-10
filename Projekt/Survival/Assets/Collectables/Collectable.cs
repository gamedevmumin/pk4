using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    PlayerCollectables playerCollectables;
    [SerializeField]
    Item item;
    bool isCollected = false;
    [SerializeField]
    GameEvent onCollection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isCollected)
        {
            playerCollectables.Collect(item);           
            isCollected = true;
            onCollection.Raise();
            Destroy(gameObject);
        }
    }

    
}
