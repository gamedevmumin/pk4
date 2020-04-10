using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField]
    GameObject parent;

    [SerializeField]
    string buildingName;

    [SerializeField]
    Text buldingNameText;

    [SerializeField]
    Image slotImage;

    [SerializeField]
    Transform itemsPanel;

    [System.Serializable]
    struct BuildingRequirment
    {
        [SerializeField]
        public Item requiredItem;
        [SerializeField]
        public int requiredAmount;
    }

    CameraShake cS;

    [SerializeField]
    List<BuildingRequirment> buildingRequirments;
    [SerializeField]
    string sound = "Hammer2"; 
    class ItemUI
    {
        public Image slotImage;
        public Image itemImage;
        public Text requirmentText;
    }
    [SerializeField]
    List<ItemUI> itemUIs;

    bool isPlayerInRange = false;

    [SerializeField]
    Building building;

    [SerializeField]
    List<Building> additionalBuildings;
    

    [SerializeField]
    GameEvent onBuilt;

    [SerializeField]
    Text infoText;


    void Awake()
    {
        itemUIs = new List<ItemUI>();
        for (int i = 0; i < buildingRequirments.Count; i++)
        {
            itemUIs.Add(new ItemUI());
            GameObject go = Instantiate(slotImage, itemsPanel).gameObject;
            itemUIs[i].slotImage = go.GetComponent<Image>();
            itemUIs[i].itemImage = go.transform.Find("ItemImage").GetComponent<Image>();
            itemUIs[i].requirmentText = go.transform.Find("Text").GetComponent<Text>();
        }
        cS = GameObject.Find("CameraShake").GetComponent<CameraShake>();
        buldingNameText.text = buildingName;
    }
    bool isBuilt = false;
    // Update is called once per frame
    void Update()
    {
        if(!isBuilt && isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool areRequirmentsMet = true;
            for(int i = 0; i<buildingRequirments.Count; i++)
            {
                Debug.Log(buildingRequirments[i].requiredAmount + "  " + buildingRequirments[i].requiredItem.Amount);
                if (buildingRequirments[i].requiredAmount > buildingRequirments[i].requiredItem.Amount)
                {
                    areRequirmentsMet = false;
                    break;
                }
            }

            if (areRequirmentsMet)
            {
                building.Build();
                foreach (Building b in additionalBuildings)
                {
                    b.Build();
                }
                isBuilt = true;
                for (int i = 0; i < buildingRequirments.Count; i++)
                {
                    buildingRequirments[i].requiredItem.Amount -= buildingRequirments[i].requiredAmount;
                    itemUIs[i].itemImage.enabled = false;
                    itemUIs[i].requirmentText.enabled = false;
                    itemUIs[i].slotImage.enabled = false;
                    infoText.enabled = false;
                    buldingNameText.enabled = false;
                    onBuilt.Raise();
                }
                AudioManager.instance.PlaySound(sound);
                cS.Shake(0.035f, 0.05f);
                Destroy(parent);
            }
            else AudioManager.instance.PlaySound("Error");
        }
    }

    public void OnHighlight()
    {
        int i = 0;
        foreach (BuildingRequirment entry in buildingRequirments)
        {
            itemUIs[i].itemImage.sprite = entry.requiredItem.Icon;  
            itemUIs[i].requirmentText.text = entry.requiredItem.Amount.ToString() + "/" + entry.requiredAmount;
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
