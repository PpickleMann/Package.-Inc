using UnityEngine;
using UnityEngine.UI;

public class Tabs : MonoBehaviour
{
    public GameObject[] pages;

    void Start()
    {
        ActivateTab(0);
    }
    
    public void ActivateTab(int tabNum)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        pages[tabNum].SetActive(true);
    }
}
