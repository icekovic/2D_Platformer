using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 1f;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate ()
    {
        musicVolume = PlayerPrefs.GetFloat("Volume");
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("Volume", musicVolume);
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }

    public float GetVolume()
    {
        return musicVolume;
    }
}