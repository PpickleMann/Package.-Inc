using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BusinessNameNDes : MonoBehaviour
{
    private string nameInput;
    private string desInput;
    private string IncInput;
    public TextMeshProUGUI websiteInc;
    public TextMeshProUGUI websiteDes;

    public GameObject nameNThing;

    public void GetName(string name)
    {
        nameInput = name;
        websiteInc.text = nameInput + IncInput;
    }

    public void GetDes(string des)
    {
        desInput = des;
        websiteDes.text = desInput;
    }

    void Awake()
    {
        IncInput = " Inc";
    }

    public void Exit()
    {
        nameNThing.SetActive(false);
        websiteInc.text = nameInput + IncInput;
        websiteDes.text = desInput;
    }

    public void corpTime(int index)
    {
        switch (index)
        {
            
            case 0: IncInput = " Inc"; break;
            case 1: IncInput = " Co"; break;
            case 2: IncInput = " LLC"; break;
            case 3: IncInput = " Corp"; break;
            case 4: IncInput = " Ltd"; break;
        }
    }
}
