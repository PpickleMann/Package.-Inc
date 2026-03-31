using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndingScripts : MonoBehaviour
{
    public int boxsDone;

    public GameObject catScreen;
    public GameObject catOG;

    public GameObject EndScreen;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI endingText;
    public Money money;
    public CatCoShop catCoShop;
    public bool hasCat = false;

    public GameObject cat;
    float spawnCoolDown = 90f;
    float sizeX = 70f;
    float sizeY = 10f;
    float SpawnTime;

    public void Start()
    {
        SpawnTime = spawnCoolDown;
    }

    void Update()
    {
        if (hasCat)
        {
        if (SpawnTime > 0 && hasCat) SpawnTime -= Time.deltaTime;

        if (SpawnTime <= 0 && hasCat)
        {
            Spawn();
            SpawnTime = spawnCoolDown;
        }
        }
    }

    void Spawn()
    {
        if (hasCat)
        {
        float xPos = (Random.value - 0.5f) * 2 * sizeX;
        float yPos = (Random.value - 0.5f) * 2 * sizeY;

        var Spawn = Instantiate(cat);
        cat.transform.position = new  Vector3(xPos, yPos, 0);
        }
    }


    public void BeatGameMaybe()
    {
        if (boxsDone == 20)
        CatEvent();

        if (boxsDone == 100)
        {
            Debug.Log("You Beat The Game");
            EndScreen.SetActive(true);
            if (hasCat)
            {
                endText.text = "The cat has multiplied and they took over the world! you now work for the cats";
                endingText.text = "Ending 1/4";
            }
            else if (catCoShop.hasBoughtMac1 && catCoShop.hasBoughtMac2 && catCoShop.hasBoughtMac3)
            {
                endText.text = "Because you bought all the robots, you are now a worker for your robot overlords!";
                endingText.text = "Ending 2/4";
            }
            else if (money.money >= 100)
            {
                endText.text = "You Became The Richest Person In The World. You are now being perused by the IRS for tax fraud!";
                endingText.text = "Ending 3/4";
            }
            else if (money.money <= 20)
            {
                endText.text = "Your company has filed for bankruptcy and your gandma regrets adopting you";
                endingText.text = "Ending 4/4";
            }
            else
            {
                endText.text = "How Did you not get any of the normal endings??? you didn't even adopt the cat!?!?! WHY!?!?";
                endingText.text = "Ending 5/4";
            }
        }
    }

    public void CatEvent()
    {
        Debug.Log("Cat?");
        catScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        EndScreen.SetActive(false);
    }

    public void QuitToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void CatCat(int yes)
    {
        if (yes == 1)
        {
            hasCat = true;
            catOG.SetActive(true);
            catScreen.SetActive(false);
        }
        else
        {
            hasCat = false;
            catOG.SetActive(false);
            catScreen.SetActive(false);
        }
    }
}
