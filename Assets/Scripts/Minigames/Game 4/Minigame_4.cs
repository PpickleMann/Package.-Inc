using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame_4 : MonoBehaviour
{
    public GameObject stampUI;

    public GameObject[] stamp;

    public void StampUi(int OnOff)
    {
        if (OnOff == 1)
        {
            stampUI.SetActive(true);
        }
        else if (OnOff == 2)
        {
           stampUI.SetActive(false); 
        }
    }

    public void PressedBox()
    {
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
            Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 offset = new Vector3(0, 0, 10);
            Instantiate(stamp[0], pos + offset, Quaternion.identity);
        //}
    }
}
