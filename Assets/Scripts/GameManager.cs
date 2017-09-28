using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    AudioClip levelComplete;
    [SerializeField]
    AudioClip death;
    AudioSource asrc;
    [SerializeField]
    float timerDuration;
    bool time = false;
	// Use this for initialization
	void Start () {
        asrc = GetComponent<AudioSource>();
        
	}

    internal void ResetLevel() {
        asrc.clip = death;
        asrc.loop = false;
        asrc.Play();
        timerDuration = asrc.clip.length + 1;
        time = true;
    }

    // Update is called once per frame
    void Update () {
        if (time) timerDuration -= Time.deltaTime;
        if(timerDuration <= 0f) SceneManager.LoadScene("Level01");
    }
    public void FinishGame() {
        asrc.clip = levelComplete;
        asrc.loop = false;
        asrc.Play();
        timerDuration = asrc.clip.length + 1;
        time = true;
        
    }
}