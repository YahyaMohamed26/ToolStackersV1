using System.Collections;
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
    public int index;
    public int cardNo;

    public Card()
    {

    }

    public Card (int _index, string _cardName, int _tier, string _cardDescription, Sprite _logo, int _id, int _cardNo = 0)
    {
        id = _id;
        cardName = _cardName;
        tier = _tier;
        cardDescription = _cardDescription;
        logo = _logo;
        index = _index;
        cardNo = _cardNo;
    }

}
