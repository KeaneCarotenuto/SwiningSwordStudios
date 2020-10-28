﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float health = 100;
    public float healthMax = 100;
    public float mana = 100;
    public float manaMax = 100;
    public float stamina = 100;
    public float staminaMax = 100;
    public float healthIncreasePerSecond = 1;
    public float manaIncreasePerSecond = 5;
    public float staminaIncreasePerSecond = 5;

    public ResourceBar healthbar;
    public ResourceBar manabar;
    public ResourceBar staminabar;

    //Seting the variables for the resourcebar slider
    void SetHealth()
    {
        health = healthMax;
        healthbar.SetMaxResource(healthMax);
    }
    void SetMana()
    {
        mana = manaMax;
        manabar.SetMaxResource(manaMax);
    }
    void SetStamina()
    {
        stamina = staminaMax;
        staminabar.SetMaxResource(staminaMax);
    }


    // Start is called before the first frame update
    void Start()
    {
        SetHealth();
        SetMana();
        SetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        //Testing functionality
        //X to reduce health, left click to reduce mana, space to reduce stamina
        if(Input.GetKeyDown(KeyCode.X))
        {
            UpdateHealthBar(20);
        }

       if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UpdateManaBar(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateStaminaBar(20);
        }
        HealthRegen();
        ManaRegen();
        StaminaRegen();
    }

    //Function to update resource bar after performing an action
    void UpdateHealthBar(int cost)
    {
        health -= cost;
        healthbar.SetResource(health);
        if(health < 0)
        {
            health = 0;
        }
    }
    void UpdateManaBar(int cost)
    {
        mana -= cost;
        manabar.SetResource(mana);
        if (mana < 0)
        {
            mana = 0;
        }
    }
    void UpdateStaminaBar(int cost)
    {
        stamina -= cost;
        staminabar.SetResource(stamina);
        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    //Resource regeneration over time
    void HealthRegen()
    {
        health += healthIncreasePerSecond * Time.deltaTime;

        if (health > 100)
        {
            health = 100;
        }
        healthbar.SetResource(health);
    }

    void ManaRegen()
    {
        mana += manaIncreasePerSecond * Time.deltaTime;

        if (mana > 100)
        {
            mana = 100;
        }
        manabar.SetResource(mana);
    }

    void StaminaRegen()
    {
        stamina += staminaIncreasePerSecond * Time.deltaTime;

        if (stamina > 100)
        {
            stamina = 100;
        }
        staminabar.SetResource(stamina);
    }
}