using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerController : MonoBehaviour
{

    public float radius;
    public float maxBarHeight;
    public int sampleSize;

    public GameObject frequencyBar;

    public AudioSource source;

    float[] sampleArray;
    GameObject[] objectArray;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(sampleSize >= 64 && sampleSize <= 8192 && Mathf.ClosestPowerOfTwo(sampleSize) == sampleSize);

        sampleArray = new float[sampleSize];
        objectArray = new GameObject[sampleSize * 2];

        //source = this.GetComponent<AudioSource>();


        Vector3 initPos = new Vector3(radius, 0, 0);

        //Create a frequency bar for each frequency in the sample array
        for (int i = 0; i < objectArray.Length; i++)
        {
            //Create and place the object at the parent position
            objectArray[i] = GameObject.Instantiate(frequencyBar, this.transform.position, this.transform.rotation);
            objectArray[i].transform.parent = this.transform;

            Vector3 rotation = new Vector3(0, (360.0f / objectArray.Length) * i, 0);
            objectArray[i].transform.Rotate(rotation);
            objectArray[i].transform.Translate(initPos);
        }

        Color red = new Color(225, 0, 0, 225);

        objectArray[0].GetComponent<Renderer>().material.color = red;
        objectArray[0].tag = "Shield";
        objectArray[1].GetComponent<Renderer>().material.color = red;
        objectArray[1].tag = "Shield";
        objectArray[2].GetComponent<Renderer>().material.color = red;
        objectArray[2].tag = "Shield";
        objectArray[3].GetComponent<Renderer>().material.color = red;
        objectArray[3].tag = "Shield";
        objectArray[4].GetComponent<Renderer>().material.color = red;
        objectArray[4].tag = "Shield";
        objectArray[5].GetComponent<Renderer>().material.color = red;
        objectArray[5].tag = "Shield";
        objectArray[objectArray.Length - 1].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 1].tag = "Shield";
        objectArray[objectArray.Length - 2].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 2].tag = "Shield";
        objectArray[objectArray.Length - 3].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 3].tag = "Shield";
        objectArray[objectArray.Length - 4].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 4].tag = "Shield";
        objectArray[objectArray.Length - 5].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 5].tag = "Shield";
        objectArray[objectArray.Length - 6].GetComponent<Renderer>().material.color = red;
        objectArray[objectArray.Length - 6].tag = "Shield";
    }

    // Update is called once per frame
    void Update()
    {
        source.GetSpectrumData(sampleArray, 0, FFTWindow.Rectangular);

        float yPos;

        int j;

        for (int i = 0; i < objectArray.Length / 2; i++)
        {
            j = objectArray.Length - i - 1;
            yPos = sampleArray[i] / 1.0f;

            //objectArray[i].GetComponent<Renderer>().material.color = new Color(225.0f * yPos, 0.0f, 0.0f, 225.0f);
            //objectArray[j].GetComponent<Renderer>().material.color = new Color(225.0f * yPos, 225.0f - (225.0f * yPos), 0.0f, 225.0f);

            yPos = yPos * maxBarHeight;

            objectArray[i].transform.localPosition = Vector3.zero;
            objectArray[i].transform.Translate(new Vector3(radius + yPos, 0, 0));
            objectArray[j].transform.localPosition = Vector3.zero;
            objectArray[j].transform.Translate(new Vector3(radius + yPos, 0, 0));
        }
    }

    private void BPM()
    {

    }
}
