using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardsList = new List<Card>();

    private void Awake()
    {
        cardsList.Add(new Card(0, "Code Review", 1, "This is code review", Resources.Load<Sprite>("1 CR"), "Purple"));
        cardsList.Add(new Card(1, "Code Review", 1, "This is code review", Resources.Load<Sprite>("2 CR"), "Purple"));
        cardsList.Add(new Card(2, "Code Review", 1, "This is code review", Resources.Load<Sprite>("3 CR"), "Purple"));
        cardsList.Add(new Card(3, "Code Review", 1, "This is code review", Resources.Load<Sprite>("4 CR"), "Purple"));
        cardsList.Add(new Card(4, "Code Review", 1, "This is code review", Resources.Load<Sprite>("5 CR"), "Purple"));
        cardsList.Add(new Card(5, "Version Control", 1, "None", Resources.Load<Sprite>("1 VC"), "Yellow"));
        cardsList.Add(new Card(6, "Version Control", 1, "None", Resources.Load<Sprite>("2 VC"), "Yellow"));
        cardsList.Add(new Card(7, "Version Control", 1, "None", Resources.Load<Sprite>("3 VC"), "Yellow"));
        cardsList.Add(new Card(8, "Version Control", 1, "None", Resources.Load<Sprite>("4 VC"), "Yellow"));
        cardsList.Add(new Card(9, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("1 CN"), "Blue"));
        cardsList.Add(new Card(10, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("2 CN"), "Blue"));
        cardsList.Add(new Card(11, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("3 CN"), "Blue"));
        cardsList.Add(new Card(12, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("4 CN"), "Blue"));
        cardsList.Add(new Card(13, "Continuous Integeration", 1, "None", Resources.Load<Sprite>("5 CN"), "Blue"));
        cardsList.Add(new Card(14, "Issue Tracking", 1, "None", Resources.Load<Sprite>("1 BT"), "Green"));
        cardsList.Add(new Card(15, "Issue Tracking", 1, "None", Resources.Load<Sprite>("2 BT"), "Green"));
        cardsList.Add(new Card(16, "Issue Tracking", 1, "None", Resources.Load<Sprite>("3 BT"), "Green"));
        cardsList.Add(new Card(17, "Issue Tracking", 1, "None", Resources.Load<Sprite>("4 BT"), "Green"));
        cardsList.Add(new Card(18, "Project Management", 1, "None", Resources.Load<Sprite>("1 PM"), "Red"));
        cardsList.Add(new Card(19, "Project Management", 1, "None", Resources.Load<Sprite>("2 PM"), "Red"));
        cardsList.Add(new Card(20, "Project Management", 1, "None", Resources.Load<Sprite>("3 PM"), "Red"));
        cardsList.Add(new Card(21, "Project Management", 1, "None", Resources.Load<Sprite>("4 PM"), "Red"));
        cardsList.Add(new Card(22, "Project Management", 1, "None", Resources.Load<Sprite>("5 PM"), "Red"));
        cardsList.Add(new Card(23, "Basic 1", 1, "None", Resources.Load<Sprite>("1 Basic"), "Blue"));
        cardsList.Add(new Card(24, "Basic 2", 1, "None", Resources.Load<Sprite>("2 Basic"), "Blue"));
        cardsList.Add(new Card(25, "Basic 3", 1, "None", Resources.Load<Sprite>("3 Basic"), "Blue"));
        cardsList.Add(new Card(26, "Basic 4", 1, "None", Resources.Load<Sprite>("4 Basic"), "Blue"));
        cardsList.Add(new Card(27, "Basic 5", 1, "None", Resources.Load<Sprite>("5 Basic"), "Blue"));
        cardsList.Add(new Card(28, "Easy 1", 1, "None", Resources.Load<Sprite>("1 Easy"), "Red"));
        cardsList.Add(new Card(29, "Easy 1", 1, "None", Resources.Load<Sprite>("2 Easy"), "Red"));
        cardsList.Add(new Card(30, "Easy 1", 1, "None", Resources.Load<Sprite>("3 Easy"), "Red"));
        cardsList.Add(new Card(31, "Easy 1", 1, "None", Resources.Load<Sprite>("4 Easy"), "Red"));
        cardsList.Add(new Card(32, "Easy 1", 1, "None", Resources.Load<Sprite>("5 Easy"), "Red"));
        cardsList.Add(new Card(33, "Hard 1", 1, "None", Resources.Load<Sprite>("1 Hard"), "Yellow"));
        cardsList.Add(new Card(34, "Hard 1", 1, "None", Resources.Load<Sprite>("2 Hard"), "Yellow"));
        cardsList.Add(new Card(35, "Hard 1", 1, "None", Resources.Load<Sprite>("3 Hard"), "Yellow"));
        cardsList.Add(new Card(36, "Hard 1", 1, "None", Resources.Load<Sprite>("4 Hard"), "Yellow"));
        cardsList.Add(new Card(37, "Hard 1", 1, "None", Resources.Load<Sprite>("5 Hard"), "Yellow"));
        cardsList.Add(new Card(38, "Upgrade Card", 1, "None", Resources.Load<Sprite>("7"), "Red"));
    }
}
