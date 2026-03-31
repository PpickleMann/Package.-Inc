using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSourse;
    [SerializeField] AudioSource SFXSourse;

    [Header("Audio Clip")]
    public AudioClip GoodNoise;
    public AudioClip BadNoise;
    public AudioClip Words;
    public AudioClip TempMusic;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSourse.clip = TempMusic;
        musicSourse.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSourse.PlayOneShot(clip);
    }
}
