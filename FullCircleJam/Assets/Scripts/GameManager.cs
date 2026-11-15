using System.ComponentModel;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Variables")]
    public int noteCounter;

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

    [Header("Audio")]
    public AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (noteCounter > GetComponent<NoteSpawner>().noteGenAmount)
            SceneManager.LoadScene("EndScene");
    }

    public void NoteHit()
    {
        ChangeLoop();
        speedMultiplier+=0.01f;
        bpm = bpm*speedMultiplier;
        audioSource.pitch = speedMultiplier;
    }

    public void BadHit()
    {
        speedMultiplier = 1;
        bpm = startingBpm;
        audioSource.pitch = speedMultiplier;
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
