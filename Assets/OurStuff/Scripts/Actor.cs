﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
     This class is attached to every actor in the game. 
     It has datas and functions that relates to them.
 */
public class Actor : MonoBehaviour
{
    /*--- Variables ---*/
    public string name;
    public Faction faction;
    // Actor Values

    public float health;
    public float healthMax;
    public float mana;
    public float manaMax;
    public float stamina;
    public float staminaMax;
    public float aggression;
    public float attackDamage;
    public float attackSpeed;
    public float moveSpeed;
    public float damageResistance;
    public float spellResistance;
    // User Interface
    public Slider healthbar;
    public GameObject healthBarUI;
    /*--- ---*/
    void Start()
    {
        SetDefaultAV();
    }


    void Update()
    {
        UpdateHealthBar();
        if(health <= 0)
        {
            // dead
            Destroy(gameObject);
        }
    }

    /*--- Get() Functions ---*/
    public string GetName()
    {
        return name;
    }

    public Faction GetFaction()
    {
        return faction;
    }
    public float GetActorValue(string _sValue)
    {
        switch (_sValue)
        {
            case "health":
                return health;
            case "healthmax":
                return healthMax;
            case "mana":
                return mana;
            case "manaMax":
                return manaMax;
            case "stamina":
                return stamina;
            case "staminaMax":
                return staminaMax;
            case "aggression":
                return aggression;
            case "attackDamage":
                return attackDamage;
            case "attackSpeed":
                return attackSpeed;
            case "moveSpeed":
                return moveSpeed;
            case "damageResistance":
                return damageResistance;
            case "spellResistance":
                return spellResistance;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                return 0;
        }
    }

    public float GetAV(string _sValue)
    {
        // Just a shorthand version of GEtActorValue(). Might delete one of them later.
        switch (_sValue)
        {
            case "health":
                return health;
            case "healthmax":
                return healthMax;
            case "mana":
                return mana;
            case "manamax":
                return manaMax;
            case "stamina":
                return stamina;
            case "staminamax":
                return staminaMax;
            case "aggression":
                return aggression;
            case "attackDamage":
                return attackDamage;
            case "attackSpeed":
                return attackSpeed;
            case "moveSpeed":
                return moveSpeed;
            case "damageResistance":
                return damageResistance;
            case "spellResistance":
                return spellResistance;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                return 0;
        }
    }

    // public MagicEffect[] GetActiveMagicEffects()
    // {
    //     This retrieves all the active magic effects that the actor is currently experiencing.
    //     Will develop more later
    // }

    /*--- Is/has() Functions ---*/
    //public bool IsInFaction(Faction[] _aFactionList){}; Checks if this actor is in one of the factions in a list.
    // public bool IsInCombat() {}; // Check if this person is in combat
    // public bool IsDead() {}; // Check if actor is dead
    // public bool IsDisabled() {};
    // More to be added later.
    /*--- Set() Functions ---*/
    public void SetName(string _sNewName)
    {
        name = _sNewName;
    }

    public void SetActorValue(string _sValueName, float _iNewValue)
    {
        switch (_sValueName)
        {
            case "health":
                health = _iNewValue;
                break;
            case "healthmax":
                healthMax = _iNewValue;
                break;
            case "mana":
                mana = _iNewValue;
                break;
            case "manamax":
                manaMax = _iNewValue;
                break;
            case "stamina":
                stamina = _iNewValue;
                break;
            case "staminamax":
                staminaMax = _iNewValue;
                break;
            case "aggression":
                aggression = _iNewValue;
                break;
            case "attackDamage":
                attackDamage = _iNewValue;
                break;
            case "attackSpeed":
                attackSpeed = _iNewValue;
                break;
            case "moveSpeed":
                moveSpeed = _iNewValue;
                break;
            case "damageResistance":
                damageResistance = _iNewValue;
                break;
            case "spellResistance":
                spellResistance = _iNewValue;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void SetAV(string _sValueName, float _iNewValue)
    {
        // Shorthand version of setactorvalue()
        switch (_sValueName)
        {
            case "health":
                health = _iNewValue;
                break;
            case "healthmax":
                healthMax = _iNewValue;
                break;
            case "mana":
                mana = _iNewValue;
                break;
            case "manamax":
                manaMax = _iNewValue;
                break;
            case "stamina":
                stamina = _iNewValue;
                break;
            case "staminamax":
                staminaMax = _iNewValue;
                break;
            case "aggression":
                aggression = _iNewValue;
                break;
            case "attackDamage":
                attackDamage = _iNewValue;
                break;
            case "attackSpeed":
                attackSpeed = _iNewValue;
                break;
            case "moveSpeed":
                moveSpeed = _iNewValue;
                break;
            case "damageResistance":
                damageResistance = _iNewValue;
                break;
            case "spellResistance":
                spellResistance = _iNewValue;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    void SetDefaultAV()
    {
        healthMax = 100;
        health = healthMax;
        manaMax = 100;
        mana = manaMax;
        staminaMax = 100;
        stamina = staminaMax;
    }

    /*--- Actions ---*/
    void Kill() { }
    void Disable() { }

    public void DamageActorValue(string _sValue, float _iAmount)
    {
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void DamageAV(string _sValue, float _iAmount)
    {
        // Shorthand version of damageactorvalue(). Will only keep one by the end.
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void RestoreActorValue(string _sValue, float _iAmount)
    {
        // Increase actor value. AKA, healing them. WIP
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void RestoreAV(string _sValue, float _iAmount)
    {
        // Shorthand version of RestoreActorValue()
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    // public void ApplyMagicEffect(MagicEffect _aMagicEffect) { }

    public void TakeDamage(float _iDamage)
    {
        DamageAV("health", _iDamage);
    }

    /*--- Calculate Functions ---*/


    float CalculateDamage(float _iDamage)
    {
        // Calculate the final damage to be taken, taking account the actor's damage and spell resistance
        // WIP
        float iNewValue = _iDamage - damageResistance;
        if (iNewValue < 0)
        {
            iNewValue = 0;
        }
        return iNewValue;
    }
    /*--- UI Functions ---*/
    float CalculateHealthBar()
    {
        // This is to use with the floating healthbar, so it displays the correct amount.
        return health / healthMax;
    }

    void UpdateHealthBar()
    {
        healthbar.value = CalculateHealthBar();

        if (health < healthMax)
        {
            healthBarUI.SetActive(true);
        }
        else if (health > healthMax)
        {
            health = healthMax;
        }
    }




}