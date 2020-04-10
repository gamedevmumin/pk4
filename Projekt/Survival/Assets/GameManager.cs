using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    [SerializeField]
    Text upgHouse;
    [SerializeField]
    Text trees;
    [SerializeField]
    Text cross1, cross2;

    [SerializeField]
    GameObject UI;
    [SerializeField]
    GameObject screen;
    [SerializeField]
    PlayerStats stats;
    [SerializeField]
    Sprite destroyed;
    [SerializeField]
    Text infoText;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upgHouse.text = "Upgrade house: " + (Base.phase + 1).ToString() + "/3";
        trees.text = "Grow trees: " + (Regrowth.treesAmount).ToString() + "/8";
        if ((Base.phase + 1) == 3) cross1.text = "x";
        if (Regrowth.treesAmount >= 8) cross2.text = "x";
        if ((Base.phase + 1) == 3 && Regrowth.treesAmount >= 8 && !finished)
        {
            finished = true;
            AudioManager.instance.PlaySound("Win");
            UI.SetActive(false);
            screen.SetActive(true);
        }
        if (stats.currentHP <= 0 && !finished)
        {
            UI.SetActive(false);
            finished = true;
            AudioManager.instance.PlaySound("Lose");
            screen.SetActive(true);
            screen.GetComponent<Image>().sprite = destroyed;
            infoText.text = "You lost!";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            stats.currentHP = 100;
            stats.hunger = 100;
            stats.upgraded = false;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
