using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusicBGM();
    }

    void PlayMusicBGM()
    {
        musicBGM.Play();
        musicBGM.volume = 0.2F;
    }

}
