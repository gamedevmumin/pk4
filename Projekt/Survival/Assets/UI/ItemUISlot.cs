using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUISlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    List<Text> textsToShow;

    [SerializeField]
    EquipmentUI equipmentUI;

    public Item item;

    bool isMouseInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Text text in textsToShow)
        {
            text.enabled = false;
        }
    }

    bool canUse = true;

    IEnumerator block()
    {
        canUse = false;
        yield return new WaitForSeconds(0.2f);
        canUse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMouseInRange && item)
        {
            if(Input.GetMouseButton(1))
            {
                if (canUse && item.Usable && item.Amount > 0)
                {
                    StartCoroutine(block());
                    item.Use();
                    
                }
                else
                {
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(Text text in textsToShow)
        {
            text.enabled = true;
            isMouseInRange = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (Text text in textsToShow)
        {
            text.enabled = false;
            isMouseInRange = false;
        }
    }
}
