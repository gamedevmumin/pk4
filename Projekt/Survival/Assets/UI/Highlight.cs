using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{

    bool isPlayerInRange = false;

    [SerializeField]
    GameObject highlight;
    [SerializeField]
    GameEvent onHighlight;

    private void Start()
    {
        highlight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            highlight.SetActive(true);
            onHighlight.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            highlight.SetActive(false);
        }
    }
}
