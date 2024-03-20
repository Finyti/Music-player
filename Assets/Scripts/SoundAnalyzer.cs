using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundAnalyzer : MonoBehaviour
{
    AudioSource source;

    public static UnityEvent<float> onVolumeChnged = new();
    void Start()
    {
        source = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
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


}
