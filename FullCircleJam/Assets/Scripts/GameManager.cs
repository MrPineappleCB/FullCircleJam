using System.ComponentModel;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Settings")]
    public float bpm;
    public float startingBpm;
    public float speedMultiplier = 1;

    [Header("Key Loop")]
    public KeyCode KeyToPress;
    public int KeyLoop = 0;
    public List<KeyCode> Keys = new List<KeyCode>();

    [Header("UI")]
    public Image keyToPressImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoteHit()
    {
        Debug.Log("it");
        ChangeLoop();
        speedMultiplier+=0.01f;
        bpm = bpm*speedMultiplier;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        speedMultiplier = 1;
        bpm = startingBpm;
    }

    public void WrongNoteHit()
    {
        Debug.Log("Wrong Note");
        speedMultiplier = 1;
        bpm = startingBpm;
    }

    public void ChangeLoop()
    {
        KeyLoop++;
        if (KeyLoop > 5)
            KeyLoop = 0;

        KeyToPress = Keys[KeyLoop];
        keyToPressImage.sprite = GetComponent<NoteSpawner>().sprites[KeyLoop];
    }
}
