using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = "$" + money.ToString();
    }
}
