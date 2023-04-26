using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm; //BPM = 120
    [SerializeField] private AudioSource _aSource; //music 
    [SerializeField] private Intervals[] intervalz; //interval array                                               


    private void Update()
    {
        foreach (Intervals intervals in intervalz)
        {
            //grabs our elapsed time from audio source 
            float sampledTime = (_aSource.timeSamples / (_aSource.clip.frequency * intervals.getIntervalLength(bpm)));
            //Sends our elapsed time down to checkforNewInterval method to check if a new beat has been reached
            intervals.checkforNewInterval(sampledTime); 
        }
    }
    [System.Serializable]

    public class Intervals
    {

        [SerializeField] private float noteLength;
        [SerializeField] private UnityEvent trigger;
        private int lastInterval; //to check when the last interval was recorded

        public float getIntervalLength(float bpm) //measures length of our beat
        {
            return 60f / (bpm * noteLength);
        }

        public void checkforNewInterval (float interval) //checks for new whole number, meaning a beat has passed
        {
            if (Mathf.FloorToInt(interval) != lastInterval) //if our recored beat != the previous beat 
            {
                lastInterval = Mathf.FloorToInt(interval); //rounds interval recorded, as framerates will never be a "true" whole number
                trigger.Invoke();
            }
        }
    }




}
