using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardsList = new List<Card>();

    private void Awake()
    {
        cardsList.Add(new Card(0, "Code Review", 1, "This is code review", Resources.Load<Sprite>("1 CR"), 0));
        cardsList.Add(new Card(1, "Code Review", 1, "This is code review", Resources.Load<Sprite>("2 CR"), 1));
        cardsList.Add(new Card(2, "Code Review", 1, "This is code review", Resources.Load<Sprite>("3 CR"), 2));
        cardsList.Add(new Card(3, "Code Review", 1, "This is code review", Resources.Load<Sprite>("4 CR"), 3));
        cardsList.Add(new Card(4, "Code Review", 1, "This is code review", Resources.Load<Sprite>("5 CR"), 4));
        cardsList.Add(new Card(5, "Version Control", 1, "None", Resources.Load<Sprite>("1 VC"), 5));
        cardsList.Add(new Card(6, "Version Control", 1, "None", Resources.Load<Sprite>("2 VC"), 6));
        cardsList.Add(new Card(7, "Version Control", 1, "None", Resources.Load<Sprite>("3 VC"), 7));
        cardsList.Add(new Card(8, "Version Control", 1, "None", Resources.Load<Sprite>("4 VC"), 8));
        cardsList.Add(new Card(9, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("1 CN"), 9));
        cardsList.Add(new Card(10, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("2 CN"), 10));
        cardsList.Add(new Card(11, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("3 CN"), 11));
        cardsList.Add(new Card(12, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("4 CN"), 12));
        cardsList.Add(new Card(13, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("5 CN"), 13));
        cardsList.Add(new Card(14, "Issue Tracking", 1, "None", Resources.Load<Sprite>("1 BT"), 14));
        cardsList.Add(new Card(15, "Issue Tracking", 1, "None", Resources.Load<Sprite>("2 BT"), 15));
        cardsList.Add(new Card(16, "Issue Tracking", 1, "None", Resources.Load<Sprite>("3 BT"), 16));
        cardsList.Add(new Card(17, "Issue Tracking", 1, "None", Resources.Load<Sprite>("4 BT"), 17));
        cardsList.Add(new Card(18, "Project Management", 1, "None", Resources.Load<Sprite>("1 PM"), 18));
        cardsList.Add(new Card(19, "Project Management", 1, "None", Resources.Load<Sprite>("2 PM"), 19));
        cardsList.Add(new Card(20, "Project Management", 1, "None", Resources.Load<Sprite>("3 PM"), 20));
        cardsList.Add(new Card(21, "Project Management", 1, "None", Resources.Load<Sprite>("4 PM"), 21));
        cardsList.Add(new Card(22, "Project Management", 1, "None", Resources.Load<Sprite>("5 PM"), 22));
        cardsList.Add(new Card(23, "Basic 1", 1, "None", Resources.Load<Sprite>("1 Basic"), 23));
        cardsList.Add(new Card(24, "Basic 2", 1, "None", Resources.Load<Sprite>("2 Basic"), 24));
        cardsList.Add(new Card(25, "Basic 3", 1, "None", Resources.Load<Sprite>("3 Basic"), 25));
        cardsList.Add(new Card(26, "Basic 4", 1, "None", Resources.Load<Sprite>("4 Basic"), 26));
        cardsList.Add(new Card(27, "Basic 5", 1, "None", Resources.Load<Sprite>("5 Basic"), 27));
        cardsList.Add(new Card(28, "Easy 1", 1, "None", Resources.Load<Sprite>("1 Easy"), 28));
        cardsList.Add(new Card(29, "Easy 1", 1, "None", Resources.Load<Sprite>("2 Easy"), 29));
        cardsList.Add(new Card(30, "Easy 1", 1, "None", Resources.Load<Sprite>("3 Easy"), 30));
        cardsList.Add(new Card(31, "Easy 1", 1, "None", Resources.Load<Sprite>("4 Easy"), 31));
        cardsList.Add(new Card(32, "Easy 1", 1, "None", Resources.Load<Sprite>("5 Easy"), 32));
        cardsList.Add(new Card(33, "Hard 1", 1, "None", Resources.Load<Sprite>("1 Hard"), 33));
        cardsList.Add(new Card(34, "Hard 1", 1, "None", Resources.Load<Sprite>("2 Hard"), 34));
        cardsList.Add(new Card(35, "Hard 1", 1, "None", Resources.Load<Sprite>("3 Hard"), 35));
        cardsList.Add(new Card(36, "Hard 1", 1, "None", Resources.Load<Sprite>("4 Hard"), 36));
        cardsList.Add(new Card(37, "Hard 1", 1, "None", Resources.Load<Sprite>("5 Hard"), 37));
        cardsList.Add(new Card(38, "Upgrade Card", 1, "None", Resources.Load<Sprite>("7"), 38));
    }
}
