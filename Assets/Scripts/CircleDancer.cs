using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Advertisements.Advertisement;

public class CircleDancer : MonoBehaviour
{
    public float count = 10;
    public float radius = 2f;
    public GameObject particlePrefab;

    public float rotateSpeed = 2f;

    public float sensitivity = 1f;

    public float objectSize = 1f;
    void Start()
    {
        for(float i = 0; i < count; i++)
        {
            float angle = i / count * (Mathf.PI * 2f);

            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);

            Vector3 pos = new Vector3(x, y, 0) * radius;

            var obj = Instantiate(particlePrefab, transform.position + pos, Quaternion.identity, transform);

            obj.transform.LookAt(transform);

            obj.GetComponent<Dancer>().startSize = objectSize;

            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            Color mixedColor = Color.Lerp(obj.GetComponent<Dancer>().startColor, obj.GetComponent<Dancer>().endColor, 0.1f) * 1.5f;
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(mixedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            obj.GetComponent<TrailRenderer>().colorGradient = gradient;
        }

        SoundAnalyzer.onVolumeChnged.AddListener(Dance);
    }


    public void Dance(float volume)
    {
        float powerRotation = Mathf.Pow(volume, sensitivity);
        transform.Rotate(0, 0, powerRotation * rotateSpeed * Time.deltaTime);



        float scaleRotation = Mathf.Pow(volume, sensitivity * 2f);
        transform.localScale = (Vector3.one * scaleRotation * 0.5f) + Vector3.one;
    }

}
