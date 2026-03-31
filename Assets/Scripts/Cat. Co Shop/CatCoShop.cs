using UnityEngine;
using TMPro;
using System.Collections;

public class CatCoShop : MonoBehaviour
{
    public bool hasBoughtMac1 = false;
    public bool hasBoughtMac2 = false;
    public bool hasBoughtMac3 = false;

    public bool hasBoughtAd1;
    public bool hasBoughtAd2;
    public bool hasBoughtAd3;

    public GameObject machine1;
    public GameObject machine2;
    public GameObject machine3;
    public TextMeshProUGUI WordsText;
    public GameObject textHolder;

    public Money money;
    public MinigameManager minigameManager;

    public void BuyMachine1()
    {
        if (money.money >= 50 && hasBoughtMac1 == false)
        {
            hasBoughtMac1 = true;
            money.money -= 50;
            minigameManager.hasMac1 = true;
            Debug.Log("Bought Test Thing");
            machine1.SetActive(true);
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtMac1 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 50 && hasBoughtMac1 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    public void BuyMachine2()
    {
        if (money.money >= 100 && hasBoughtMac2 == false)
        {
            hasBoughtMac2 = true;
            money.money -= 100;
            minigameManager.hasMac2 = true;
            Debug.Log("Bought Test Thing");
            machine2.SetActive(true);
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtMac2 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 100 && hasBoughtMac2 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    public void BuyMachine3()
    {
        if (money.money >= 200 && hasBoughtMac3 == false)
        {
            hasBoughtMac3 = true;
            money.money -= 200;
            minigameManager.hasMac3 = true;
            Debug.Log("Bought Test Thing");
            machine3.SetActive(true);
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtMac3 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 200 && hasBoughtMac3 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    public void BuyAdvertising1()
    {
        if (money.money >= 100 && hasBoughtAd1 == false)
        {
            hasBoughtAd1 = true;
            money.money -= 100;
            Debug.Log("Bought Test Thing");
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtAd1 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 100 && hasBoughtAd1 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    public void BuyAdvertising2()
    {
        if (money.money >= 150 && hasBoughtAd2 == false)
        {
            hasBoughtAd2 = true;
            money.money -= 150;
            Debug.Log("Bought Test Thing");
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtAd2 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 150 && hasBoughtAd2 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    public void BuyAdvertising3()
    {
        if (money.money >= 200 && hasBoughtAd3 == false)
        {
            hasBoughtAd3 = true;
            money.money -= 200;
            Debug.Log("Bought Test Thing");
            StartCoroutine(BoughtItem());
        }
        else if (hasBoughtAd3 == true)
        {
            Debug.Log("You Alreaghty have this item");
            StartCoroutine(AlreadyBought());
        }
        else if (money.money < 200 && hasBoughtAd3 == false)
        {
            Debug.Log("You Broke");
            StartCoroutine(YouDontHaveEnoughMoney());
        }
    }

    IEnumerator AlreadyBought()
    {
        textHolder.SetActive(true);
        WordsText.text = "Already Bought Item";
        yield return new WaitForSeconds(2);
        textHolder.SetActive(false);
    }

    IEnumerator BoughtItem()
    {
        textHolder.SetActive(true);
        WordsText.text = "Successfully Bought Item";
        yield return new WaitForSeconds(2);
        textHolder.SetActive(false);
    }

    IEnumerator YouDontHaveEnoughMoney()
    {
        textHolder.SetActive(true);
        WordsText.text = "You Don't Have Enough Money For This Item";
        yield return new WaitForSeconds(2);
        textHolder.SetActive(false);
    }
}
