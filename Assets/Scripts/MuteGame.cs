using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{
    public void muteGame()
    {
        AudioSource[] audiosSources = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < audiosSources.Length; i++)
        {
            audiosSources[i].mute = true;
        }
    }
}