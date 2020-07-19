using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    // Start is called before the first frame update

    public static List<AudioSource> _audioList = new List<AudioSource>();
    public static int _currentTrack = 0;
    void Start()
    {
        
        
    }

    void Awake()
    {
        
        startNewLevelTrack();
    }

    IEnumerator startTrack()
    {
        _audioList.Clear();
        //startNewLevelTrack();
        yield return new WaitForSeconds(0.05f);
        //if (_audioList.Count < 1)
        //{
            _audioList.Add(GetComponents<AudioSource>()[0]);
            _audioList.Add(GetComponents<AudioSource>()[1]);
            _audioList.Add(GetComponents<AudioSource>()[2]);
            _audioList.Add(GetComponents<AudioSource>()[3]);
            _audioList.Add(GetComponents<AudioSource>()[4]);
        //}
        yield return new WaitForSeconds(0.1f);
        _audioList[_currentTrack].Play();
        yield return null;
    }

    public void startNewLevelTrack()
    {
        StartCoroutine(startTrack());
    }

    public void stopLevelTrack()
    {
        _audioList[_currentTrack].Stop();
        _currentTrack++;
        if (_currentTrack >= _audioList.Count)
        {
            _currentTrack = 0;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
