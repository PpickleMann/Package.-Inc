using UnityEngine;

public class TwoButtons : MonoBehaviour
{
    public bool button1;
    public bool button2;

    public Minigame_3 minigame3;

    public void Button(int button)
    {
        if (button == 1)
        {
            button1 = true;
        }
        else if (button == 2)
        {
            button2 = true;
        }

        if (button1 && button2)
        {
            Debug.Log("Done");
            if (minigame3.doneBox1 && !minigame3.doneBox2)
            {
                minigame3.doneBox2 = true;
                minigame3.inTape = false;
                button1 = false;
                button2 = false;
                this.gameObject.SetActive(false);
            }
            else if (!minigame3.doneBox1 && !minigame3.doneBox2)
            {
                minigame3.doneBox1 = true;
                minigame3.inTape = false;
                button1 = false;
                button2 = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (minigame3.waitedToLong && !minigame3.doneBox1 && !minigame3.doneBox2)
            {
                minigame3.doneBox1 = true;
                minigame3.bad1 = true;
                minigame3.inTape = false;
                button1 = false;
                button2 = false;
                this.gameObject.SetActive(false);
                minigame3.waitedToLong = false;
            }

        if (minigame3.waitedToLong && minigame3.doneBox1 && !minigame3.doneBox2)
        {
            minigame3.doneBox2 = true;
            minigame3.bad2 = true;
            minigame3.doneBox1 = true;
            minigame3.inTape = false;
            button1 = false;
            button2 = false;
            this.gameObject.SetActive(false);
            minigame3.waitedToLong = false;
            
        }
    }
}
