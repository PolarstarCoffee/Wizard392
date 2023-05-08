using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    public AudioSource source;

    Dictionary<string, AudioClip> songDict = new Dictionary<string, AudioClip>();

    string clipsPath = "C:/Users/ggibb/Documents/GitHub/Wizard392/GAM392/Custom/AudioClips/";

    // Start is called before the first frame update
    void Start()
    {
        LoadSong("ThroughTheFireAndFlames.wav");
    }

    private void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Debug.Log("Key Pressed");
            PlaySong("ThroughTheFireAndFlames.wav");
        }
    }

    public bool LoadSong(string fileName)
    {
        //Test if the song is already loaded
        if (songDict.ContainsKey(fileName)) return true;
        else
        {
            StartCoroutine(LoadSongFromFile(fileName));
            return true;
        }
    }

    public void PlaySong(string fileName)
    {
        AudioClip clip = null;

        //If the get fails, return and play nothing
        if(!songDict.TryGetValue(fileName, out clip))
        {
            Debug.LogError("Song " + '\"' + fileName + '\"' + " not found.");
            return;
        }
        else
        {
            //Assuming the clip is found in the dictionary,

            //Check the load state to confirm audio is loaded
            if(!(clip.loadState == AudioDataLoadState.Loaded))
            {
                //In the event audio data is unloaded, attempt to load it.
                if (!clip.LoadAudioData())
                {
                    Debug.Log("AudioClip " + '\"' + fileName + '\"' + " failed to load.");
                    return;
                }
            }

            //CLIP SHOULD NOW POINT TO A VALID AUDIOCLIP OBJECT.
            source.clip = clip;
            source.Play();
        }
    }

    private IEnumerator LoadSongFromFile(string fileName)
    {
        UnityWebRequest song = UnityWebRequestMultimedia.GetAudioClip(clipsPath + fileName, AudioType.WAV);
        yield return song.SendWebRequest();

        if(song.result == UnityWebRequest.Result.Success)
        {
            AudioClip songClip = DownloadHandlerAudioClip.GetContent(song);
            songDict.Add(fileName, songClip);
        }
        else
        {
            Debug.Log(song.error);
        }
    }
}
