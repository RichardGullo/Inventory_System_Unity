﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIitems = new List<UIItem>();
    public GameObject textPrefab;
    public Transform textPanel;
    public GameObject MainMenu;
    public GameObject GoldMenu;
    public GameObject MiscellaneousMenu;
    public GameObject QuestMenu;
    public GameObject BioPanel;
    public RectTransform content;
    public Scrollbar scrollbar;

    public void addItem(Item item)
    {
        GameObject instance;
        GameObject temp;
        Color color1;
        ColorUtility.TryParseHtmlString("#323232", out color1);
        
        // Gold
        if (item.item == Item.ItemType.Gold)
        {
            instance = GoldMenu;
            temp = instance.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            temp.SetActive(true);
            temp.GetComponent<Text>().text = "" + item.count;
        }

        // Provisions
        else if(item.item == Item.ItemType.Provisions)
        {
            instance = MainMenu;
            instance.transform.GetChild(3).gameObject.SetActive(true);
            temp = instance.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
            temp.GetComponent<Text>().text = item.item + " x" + item.count;
        }

        // Ressurection
        else if(item.item == Item.ItemType.Ressurection)
        {
            instance = MainMenu;
            instance.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = color1;
            instance.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            temp = instance.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            temp.SetActive(true);
            temp.GetComponent<Text>().text = item.item + " x" + item.count;
        }

        // Miscellaneous Items
        else
        {
            instance = Instantiate(textPrefab);
            instance.GetComponent<UIItem>().item = item;
            instance.GetComponent<Text>().text = item.item + " x" + item.count;
            instance.transform.SetParent(textPanel);
            UIitems.Add(instance.GetComponent<UIItem>());
            content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + 30f);
        }
    }

    public void removeItem(Item item)
    {
        // Main Menu Items
        if (item.item == Item.ItemType.Gold || item.item == Item.ItemType.Provisions || item.item == Item.ItemType.Ressurection)
            return;

        // Only Miscellaneous Items
        foreach(UIItem UIitem in UIitems)
        {
            if (UIitem.item == item)
            {
                // count = 1 and not stackable
                if (UIitem.item.count == 1 && !(UIitem.item.stackable))
                {
                    UIitems.Remove(UIitem);
                    UIitem.destroyItem();
                    content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y - 30f);      
                }

                // count = 0 and stackable
                else if(UIitem.item.count == 0)
                {
                    UIitems.Remove(UIitem);
                    UIitem.destroyItem();
                    
                }

                // In case of any errors
                else
                    updateUIInventory(UIitem.item);

                return;
            }
        }
    }

    public void updateUIStats(Player player)
    {
        GameObject Weapon01;
        GameObject Weapon02;

        GameObject Stamina;
        GameObject Skill;
        GameObject Luck;
        GameObject Quest;

        Weapon01 = MainMenu.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        Weapon01.GetComponent<Text>().text = player.weapon01.weapon.ToString();

        Weapon02 = MainMenu.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        Weapon02.GetComponent<Text>().text = player.weapon02.weapon.ToString();

        Stamina = BioPanel.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        Stamina.GetComponent<Text>().text = "" + player.stamina + "/" + player.maxStamina;

        Skill = BioPanel.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        Skill.GetComponent<Text>().text = "" + player.skill + "/" + player.maxSkill;

        Luck = BioPanel.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        Luck.GetComponent<Text>().text = "" + player.luck + "/" + player.maxLuck;

        Quest = QuestMenu.transform.GetChild(1).gameObject;
        Quest.GetComponent<Text>().text = player.quest;
    }


    // Updates UI text
    public void updateUIInventory(Item item)
    {
        GameObject temp;
        Color color;
        ColorUtility.TryParseHtmlString("#575252", out color);

        // Gold
        if (item.item == Item.ItemType.Gold)
        {
            temp = GoldMenu.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            temp.GetComponent<Text>().text = "" + item.count;
        }
        
        // Provisions
        else if (item.item == Item.ItemType.Provisions)
        {
      
            temp = MainMenu.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
            temp.GetComponent<Text>().text = item.item + " x" + item.count;

            if(item.count == 0)
            {
                MainMenu.transform.GetChild(3).gameObject.SetActive(false);
            }
        }

        // Ressurection
        else if (item.item == Item.ItemType.Ressurection)
        {
            temp = MainMenu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            temp.GetComponent<Text>().text = item.item + " x" + item.count;

            if(item.count == 0)
            {
                temp.GetComponent<Text>().color = color;
                MainMenu.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        // Miscellaneous Items
        else
        {
            foreach (UIItem uItem in UIitems)
            {
                uItem.GetComponent<Text>().text = uItem.item.item + " x" + uItem.item.count;
            }
        }
    }
}
