using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public float Stars = 0;

    public bool hasMac1;
    public bool hasMac2;
    public bool hasMac3;
    public bool hasMac4;
    public bool hasMac5;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public bool inMinigame;

    public void AddStars(float amount)
    {
        if (Stars < 5)
        Stars += amount;
        if (Stars > 5)
        Stars = 5;
    }

    public void NoStars()
    {
        audioManager.PlaySFX(audioManager.BadNoise);
    }

    public void ResetStars()
    {
        Stars = 0f;
    }
}
