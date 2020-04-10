using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{

    public IEnumerator PlayEffect(SpriteRenderer sR)
    {
        sR.material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.03f);
        sR.material.SetFloat("_FlashAmount", 0f);
    }
}
