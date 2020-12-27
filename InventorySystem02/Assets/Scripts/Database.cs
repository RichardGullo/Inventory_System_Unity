using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    List<Item> items;
    List<Weapon> weapons;

    public void BuildDatabase()
    {
        items = new List<Item>()
        {
           new Item(Item.ItemType.Sword,false),
           new Item(Item.ItemType.Sheild,false),
           new Item(Item.ItemType.Provisions,true),
           new Item(Item.ItemType.Sword,true),
           new Item(Item.ItemType.Ressurection,true),
           new Item(Item.ItemType.Gold,true)
        };

        weapons = new List<Weapon>()
        {
            new Weapon(Weapon.WeaponType.KnightSword),
            new Weapon(Weapon.WeaponType.KnightShield),
            new Weapon(Weapon.WeaponType.MageStaff),
            new Weapon(Weapon.WeaponType.MageVeil),
            new Weapon(Weapon.WeaponType.MonkFist),
            new Weapon(Weapon.WeaponType.MonkPendant)
        };
    }

    public Item getItem(Item.ItemType item)
    {
        foreach(Item tempItem in items)
        {
            if (tempItem.item == item)
                return tempItem;
        }

        return null;
    }

    public Weapon getWeapon(Weapon.WeaponType weapon)
    {
        foreach(Weapon tempWeapon in weapons)
        {
            if (tempWeapon.weapon == weapon)
                return tempWeapon;
        }

        return null;
    }
}
