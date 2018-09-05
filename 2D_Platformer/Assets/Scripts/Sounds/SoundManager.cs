using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic;
    private AudioSource audioSourceBackgroundMusic { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip coinPickedSound;
    private AudioSource audioSourceCoin { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip levelCompletedSound;
    private AudioSource audioSourceLevelCompleted { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip playerDeadSound;
    private AudioSource audioSourcePlayerDead { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameOverSound;
    private AudioSource audioSourceGameOver { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip playerJumpSound;
    private AudioSource audioSourcePlayerJump { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameCompletedSound;
    private AudioSource audioSourceGameCompleted { get { return GetComponent<AudioSource>(); } }

    private VolumeSetting volumeSetting;
    private float volume;

    void Start ()
    {
        volumeSetting = FindObjectOfType <VolumeSetting>();
        gameObject.AddComponent<AudioSource>();

        audioSourceBackgroundMusic.clip = backgroundMusic;
        audioSourceCoin.clip = coinPickedSound;
        audioSourceLevelCompleted.clip = levelCompletedSound;
        audioSourcePlayerDead.clip = playerDeadSound;
        audioSourceGameOver.clip = gameOverSound;
        audioSourcePlayerJump.clip = playerJumpSound;
        audioSourceGameCompleted.clip = gameCompletedSound;

        PlayBackgroundMusic();
    }

    void Update ()
    {
		
	}

    public void PlayBackgroundMusic()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        audioSourceBackgroundMusic.volume = volume;
        audioSourceBackgroundMusic.PlayOneShot(backgroundMusic);
    }

    public void StopBackgroundMusic()
    {
        audioSourceBackgroundMusic.Stop();
    }

    public void PlayCoinPickedSound()
    {
        audioSourceCoin.PlayOneShot(coinPickedSound);
    }

    public void PlayLevelCompletedSound()
    {
        audioSourceLevelCompleted.PlayOneShot(levelCompletedSound);
    }

    public void PlayPlayerDeadSound()
    {
        audioSourcePlayerDead.PlayOneShot(playerDeadSound);
    }

    public void PlayGameOverSound()
    {
        audioSourceGameOver.PlayOneShot(gameOverSound);
    }

    public void PlayPlayerJumpSound()
    {
        audioSourcePlayerJump.PlayOneShot(playerJumpSound);
    }

    public void PlayGameCompletedSound()
    {
        audioSourceGameCompleted.PlayOneShot(gameCompletedSound);
    }
}