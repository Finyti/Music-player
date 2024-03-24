using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SoundAnalyzer : MonoBehaviour
{
    AudioSource source;
    public static UnityEvent<float> onVolumeChnged = new();

    public List<AudioClip> clipList;
    int currentSong = 0;

    public TextMeshProUGUI currentSongText;
    void Start()
    {
        source = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
        source.clip = clipList[currentSong];
        source.Play();

        currentSongText.text = clipList[currentSong].name;
    }

    void Update()
    {
        float[] samples = new float[735];
        source.clip.GetData(samples, source.timeSamples);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }
        float avg = sum / samples.Length;
        //print(avg);

        onVolumeChnged.Invoke(avg);
    }

    public void PreviousSong()
    {
        if (currentSong <= 0)
        {
            currentSong = clipList.Count - 1;
        }
        else
        {
            currentSong--;
        }
        source.clip = clipList[currentSong];
        source.Play();
        currentSongText.text = clipList[currentSong].name;

    }

    public void NextSong()
    {
        if(clipList.Count-1 <= currentSong)
        {
            currentSong = 0;
        }
        else
        {
            currentSong++;
        }
        source.clip = clipList[currentSong];
        source.Play();
        currentSongText.text = clipList[currentSong].name;
    }

}
