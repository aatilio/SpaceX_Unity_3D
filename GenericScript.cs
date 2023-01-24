using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScript : MonoBehaviour
{

    private int money;
    private int items;


    private UserInterface userInterface;

    private int collectableValue=5;
    private int itemCost = 10;


    void Start()
    {
        userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        money += collectableValue;
        RefreshUI();
    }
    
    public void BuyItem()
    {
        if (money >= itemCost)
        {
            items++;
            money -= itemCost;
        }
        else
        {
            Debug.Log("Can't Buy!!");
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        userInterface.RefreshMoney(money);
        userInterface.RefreshItems(items);
    }

}
