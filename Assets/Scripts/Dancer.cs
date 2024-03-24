using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Advertisements.Advertisement;

public class Dancer : MonoBehaviour
{

    public Transform dancer;
    public float power = 0.5f;
    public float startSize = 1f;

    public Color startColor;
    public Color endColor;

    public Light dancerLight;

    void Start()
    {
        dancer = GetComponent<Transform>();
        SoundAnalyzer.onVolumeChnged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        dancer.localScale = Vector3.one * (Mathf.Pow(startSize + volume, power));

        Color mixedColor = Color.Lerp(startColor, endColor, volume) * 1.5f;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", mixedColor);
        GetComponent<MeshRenderer>().material.SetFloat("_EmissionScaleUI", 1000f);

        dancerLight.color = mixedColor * 2;
        dancerLight.intensity = 0.5f + volume;


    }


}
