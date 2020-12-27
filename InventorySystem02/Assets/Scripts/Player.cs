using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Hero Name
    public string name;

    // Hero Weapons
    public Weapon weapon01;
    public Weapon weapon02;

    // Hero Stats
    public int stamina;
    public int maxStamina;

    public int luck;
    public int maxLuck;

    public int skill;
    public int maxSkill;

    // Hero Quest
    public string quest;

    public Inventory inventory;

    public Player(string name)
    {
        string quest;

        if(name == "Knight")
        {
            quest = "You have to defeat the dragon";
            this.weapon01 = new Weapon(Weapon.WeaponType.KnightSword);
            this.weapon02 = new Weapon(Weapon.WeaponType.KnightShield);
            this.quest = quest;
            this.stamina = 20;
            this.maxStamina = 20;
            this.skill = 10;
            this.maxSkill = 10;
            this.luck = 9;
            this.maxLuck = 9;
        }
        else if(name == "Mage")
        {
            quest = "You must find the book of secrets";
            this.weapon01 = new Weapon(Weapon.WeaponType.MageStaff);
            this.weapon02 = new Weapon(Weapon.WeaponType.MageVeil);
            this.quest = quest;
            this.stamina = 20;
            this.maxStamina = 20;
            this.skill = 10;
            this.maxSkill = 10;
            this.luck = 9;
            this.maxLuck = 9;
        }
        else if(name == "Monk")
        {
            quest = "You must find the shawlin temple";
            this.weapon01 = new Weapon(Weapon.WeaponType.MonkFist);
            this.weapon02 = new Weapon(Weapon.WeaponType.MonkPendant);
            this.quest = quest;
            this.stamina = 20;
            this.maxStamina = 20;
            this.skill = 10;
            this.maxSkill = 10;
            this.luck = 9;
            this.maxLuck = 9;
        }
        else
        {
            quest = "You have no name and must figure out your identity";
            this.quest = quest;
            this.stamina = 20;
            this.maxStamina = 20;
            this.skill = 10;
            this.maxSkill = 10;
            this.luck = 9;
            this.maxLuck = 9;
        }
        
    }
}
