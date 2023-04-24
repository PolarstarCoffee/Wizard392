using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerController : MonoBehaviour
{
    public float totalBarWidth;
    public float maxBarHeight;
    public int numberOfBars;

    public GameObject frequencyBar;

    AudioSource source;

    float[] sampleArray = new float[64];
    GameObject[] objectArray = new GameObject[64];

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();

        float gap = totalBarWidth / sampleArray.Length;

        Vector3 initPos = new Vector3(-(totalBarWidth / 2), 0, 0);
        initPos = initPos + this.transform.position;

        Vector3 initOffset = new Vector3(gap, 0, 0);

        //Create a frequency bar for each frequency in the sample array
        for(int i = 0; i < sampleArray.Length; i++)
        {
            objectArray[i] = GameObject.Instantiate(frequencyBar, initPos, this.transform.rotation);

            initPos = initPos + initOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        source.GetSpectrumData(sampleArray, 0, FFTWindow.Rectangular);

        float yPos;

        for(int i = 0; i < sampleArray.Length; i++)
        {
            yPos = sampleArray[i] / 1.0f;

            yPos = yPos * maxBarHeight;

            Vector3 pos = objectArray[i].transform.position;
            pos.y = yPos;
            objectArray[i].transform.SetPositionAndRotation(pos, objectArray[i].transform.rotation);
        }
    }
}
