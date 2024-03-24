using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Synth : MonoBehaviour
{
    public AudioSource audioSource;

    public float frequency;
    public float volume;

    void Start()
    {
        var clip = AudioClip.Create("Sin", 44100*10, 1, 44100, false);

        float[] data = new float[441000];

        for (int i = 0; i < data.Length; i++)
        {

            // Siren
            //var y = Mathf.Sin(Mathf.Sin(i / 13230f / (Mathf.PI * 2f)) * 14000f);
            //y += Mathf.Sin(Mathf.Sin(i / 13230f / (Mathf.PI * 2f)) * 14000f);
            //y += Mathf.Sin(Mathf.Sin(i / 13230f / (Mathf.PI * 2f)) * 14000f);
            //print(y);
            //data[i] = y * 100;

            // Lab alarm
            //var y = Mathf.Sin(i / 44100f / Mathf.PI * 2f * 9800f);
            //var y2 = Mathf.Sin(i / 44100f / Mathf.PI * 2f * 18000f);
            //print(y);
            //data[i] = (y + y2) * 0.5f * (Mathf.Sin(i / 11025f / Mathf.PI * 2f) * 5);






            // wtf??
            //var y = Mathf.Sin(i / 44100f / Mathf.PI * 2f * (Mathf.Sin((i / (Mathf.PI * 2f)) * 9800f)));


            // Emergency alarm
            //data[i] = Mathf.Sin(i / 44100f * Mathf.PI * 2f * 853f);
            //data[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2f * 960f);
            //data[i] *= 0.5f;
        }

        clip.SetData(data, 0);

        audioSource.clip = clip;

        audioSource.Play();
    }




}
