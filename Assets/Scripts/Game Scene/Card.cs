﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{

    public int id;
    public string cardName;
    public int tier;
    public string cardDescription;
    public string owner;

    public Sprite logo;
    public string color;

    public Card()
    {

    }

    public Card (int _id, string _cardName, int _tier, string _cardDescription, Sprite _logo, string _color)
    {
        id = _id;
        cardName = _cardName;
        tier = _tier;
        cardDescription = _cardDescription;
        logo = _logo;
        color = _color;
    }

}
