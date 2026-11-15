using UnityEngine;
using System.Collections.Generic;

public class NoteScript : MonoBehaviour
{

    public bool CanBePressed;
    public KeyCode noteKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(GameManager.instance.bpm/60f*Time.deltaTime, 0f, 0f);

        // if (Input.GetKeyDown(correctKey))
        // {
        //     if (CanBePressed == true)
        //     {
        //         gameObject.SetActive(false);

        //         GameManager.instance.NoteHit();
        //     }
        // }
        if (CanBePressed != true) return;

        if (noteKey == GameManager.instance.KeyToPress)
        {
            if (Input.GetKeyDown(noteKey))
            {
                GameManager.instance.NoteHit();
                Debug.Log("Correct Note");
                // GameManager.instance.noteCounter++;
                Destroy(gameObject);
                return;
            }
            
            
            foreach (KeyCode key in GameManager.instance.Keys)
            {
                //if (key == GameManager.instance.KeyToPress) return;

                if (Input.GetKeyDown(key))
                {
                    GameManager.instance.BadHit();
                    Debug.Log("Wrong key, correct note");
                    // GameManager.instance.noteCounter++;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            foreach (KeyCode key in GameManager.instance.Keys)
            {

                if (Input.GetKeyDown(key))
                {
                    GameManager.instance.BadHit();
                    Debug.Log("wrong key wrong note");
                    // GameManager.instance.noteCounter++;
                    Destroy(gameObject);
                }

            }
            if (Input.GetKeyDown(noteKey))
            {
                if (CanBePressed == true)
                {
                    GameManager.instance.BadHit();
                    Debug.Log("correct key wrong note");
                    // GameManager.instance.noteCounter++;
                    Destroy(gameObject);
                }
            }
        }
        

        // foreach (KeyCode pressedKey in wrongKeys)
        // {
        //     if (Input.GetKeyDown(pressedKey))
        //     {
        //         if (CanBePressed == true)
        //         {
        //             gameObject.SetActive(false);

        //             GameManager.instance.WrongNoteHit();
        //         }
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RhythmPoint")
        {
            CanBePressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D collison)
    {
        if(collison.tag == "RhythmPoint" && gameObject.activeSelf)
        {
            CanBePressed = false;
            if (noteKey==GameManager.instance.KeyToPress)
                GameManager.instance.BadHit();
            
            Debug.Log("Exit Trigger");
            GameManager.instance.noteCounter++;
            
            Destroy(gameObject);
        }
    }
}