using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public GameObject player;

    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;
    public Text pickupText;

    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateUI();
        PlayAudioSamples();

    }

    private void LevelCompleteCheck()
    {
        if(currentPickups >= maxPickups)
        {
            levelComplete = true;
        }
        else
        {
            levelComplete =false;
        }
    }

    private void UpdateUI()
    {
        pickupText.text = $"Pickups: {currentPickups}/{maxPickups}"; 
    }

    private void PlayAudioSamples()
    {
        for(int i = 0; i < audioSources.Length; i++)
        {
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }
}
