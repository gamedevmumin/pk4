using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{

    [SerializeField]
    Image slotImage;

    [SerializeField]
    Transform itemsPanel;

    [SerializeField]
    int slotsAmount;
    [SerializeField]
    PlayerCollectables collectables;

    class ItemUI
    {
        public Image slotImage;
        public Image itemImage;
        public Text amountText;
        public Text nameText;
        public Text infoText;
        public Item item;
        public ItemUISlot itemUI;
    }

   List<ItemUI> itemUIs;

    private void Start()
    {
        itemUIs = new List<ItemUI>();
        for (int i = 0; i< slotsAmount; i++)
        {
            itemUIs.Add(new ItemUI());
            GameObject go = Instantiate(slotImage, itemsPanel).gameObject;
            itemUIs[i].slotImage = go.GetComponent<Image>();
            itemUIs[i].itemImage = go.transform.Find("ItemImage").GetComponent<Image>();
            itemUIs[i].amountText = go.transform.Find("Text").GetComponent<Text>();
            itemUIs[i].infoText = go.transform.Find("InfoText").GetComponent<Text>();
            itemUIs[i].nameText = go.transform.Find("NameText").GetComponent<Text>();
            itemUIs[i].itemUI = go.transform.GetComponent<ItemUISlot>();
            itemUIs[i].itemUI.item = itemUIs[i].item;
        }
    }

    public void OnCollection()
    {
        int i = 0;
        foreach (KeyValuePair<string, Item> entry in collectables.items)
        {
            itemUIs[i].item = entry.Value;
            itemUIs[i].itemImage.sprite = entry.Value.Icon;
            itemUIs[i].amountText.text = entry.Value.Amount.ToString();
            itemUIs[i].infoText.text = entry.Value.Usable ? "PPM to use" : "Can't use";
            itemUIs[i].nameText.text = entry.Value.Type;
            itemUIs[i].itemUI.item = itemUIs[i].item;
            if (i > slotsAmount) break;
           i++;
        }
    }


}
