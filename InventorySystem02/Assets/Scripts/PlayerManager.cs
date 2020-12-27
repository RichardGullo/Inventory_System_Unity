using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    public Inventory inventory;
   
    void Start()
    {
        player = new Player("Mage");
        player.inventory = inventory;
        player.inventory.updateStats(player);
        player.inventory.addItem(Item.ItemType.Sword, 5);
        player.inventory.addItem(Item.ItemType.Ressurection, 3);
        player.inventory.addItem(Item.ItemType.Provisions, 5);
        player.inventory.addItem(Item.ItemType.Gold, 100);
    }

}
