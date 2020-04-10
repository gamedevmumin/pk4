using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regrowth : MonoBehaviour
{
    [SerializeField]
    bool isBackground = false;
    public static int treesAmount = 0;

    [SerializeField]
    Sprite background2, foreground2;

    [SerializeField]
    Sprite background3, foreground3;
    [SerializeField]
    SpriteRenderer sR1, sR2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(isBackground)
        {
            if(treesAmount>=4)
            {
                sR1.sprite = background2;
                sR2.sprite = foreground2;
            }
            if(treesAmount>=8)
            {
                sR1.sprite = background3;
                sR2.sprite = foreground3;
            }
        }
    }
}
