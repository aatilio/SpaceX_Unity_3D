using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserInterface : MonoBehaviour
{

    [SerializeField]
    private Text moneyIndicator;
    [SerializeField]
    private Text itemIndicator;

    private GenericScript genericScript;

    void Start()
    {
        genericScript = FindObjectOfType<GenericScript>();
    }

    void Update()
    {
        
    }

    public void RefreshMoney(int money)
    {
        moneyIndicator.text = money.ToString();
    }

    public void RefreshItems(int items)
    {
        itemIndicator.text = items.ToString();
    }

    public void BuyButton()
    {
        genericScript.BuyItem();
    }

    public void CollectButton()
    {
        genericScript.Collect();
    }


}
