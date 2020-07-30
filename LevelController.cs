using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject winLabel;
    public GameObject failLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] float waitToLoad = 4f;
    private AudioSource[] clips;
    private AudioSource winSoundClip;
    private AudioSource failSoundClip;
    private AudioSource bgm;


    private void Start()
    {
        winLabel.SetActive(false);
        failLabel.SetActive(false);
        clips = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].CompareTag("winSoundEffect")){
                winSoundClip = clips[i];
            }
            else if (clips[i].CompareTag("failSoundEffect")) {
                failSoundClip = clips[i];
            }
            else
            {
                bgm = clips[i];
            }
        }

    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;

    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            //Debug.Log("End Level Now");
            StartCoroutine(HandleWinCondition());
        }

    }
    public void HandleLoseCondition() {

        bgm.Stop();
        failLabel.SetActive(true);
        //Debug.Log("failLabel is set to active");
        failSoundClip.volume = 0.1f;
        failSoundClip.Play();
        
        //Debug.Log("fail sound clip was played.");
        Time.timeScale = 0;
       
    }

    IEnumerator HandleWinCondition()
    {
        AudioSource[] sounds = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();

        }
        
        winLabel.SetActive(true);
        //Debug.Log("winLabel has been set active.");
        winSoundClip.volume = 0.1f;
        winSoundClip.Play();
        //Debug.Log("winSoundClip is played.");
        Time.timeScale = 0;
        yield return new WaitForSeconds(waitToLoad);

        //FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();


    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }

    }
}
