using UnityEngine;

public class NoteScript : MonoBehaviour
{

    public bool CanBePressed;
    public KeyCode correctKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(correctKey))
        {
            if (CanBePressed == true)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
            }
        }
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

            GameManager.instance.NoteMissed();
        }
    }
}
