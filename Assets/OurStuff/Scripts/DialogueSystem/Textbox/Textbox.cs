﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : Textbox.cs                     
//--------------------------------------------------------//
//  Description : A dialogue box used to talk with NPCs                                       
//                                                        
//                                                       
//                                                        
//--------------------------------------------------------//
//    Author    : Nerys Thamm BSE20021                           
//--------------------------------------------------------//
//    E-mail    : Nerysthamm@gmail.com                                   
//========================================================//
////////////////////////////////////////////////////////////

public class Textbox : MonoBehaviour
{

    public Text BoxText;
    public Image BoxSprite;
    public Button Bton;

    public string CurrentText;
    public Sprite CurrentSprite;
    public TypeWriter Writer;

    public float TypeSpeed;


    // Start is called before the first frame update
    void Start()
    {
        BoxText.text = CurrentText;
        BoxSprite.sprite = CurrentSprite;
    }



    /// <summary>
    /// Destroys the text box.
    /// </summary>
    public void DestroyTextBox()
    {
        if (Writer.enabled == true) //Skip the typing and display full message
        {
            Writer.enabled = false;
            Writer.story = "";
            Writer.Typing = false;
            BoxText.text = CurrentText;
            return;
        }
        else //delete the box and get the next one
        {
            FindController F = Bton.GetComponent<FindController>();
            F.TriggerNextBox();
            Destroy(gameObject);
        }
    }
}
