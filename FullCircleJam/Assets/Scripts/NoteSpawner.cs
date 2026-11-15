using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnLocation;
    private float beatSpawnTime;
    private int currentNote = 0;
    public List<KeyCode> beatmap = new List<KeyCode>();
    public List<Sprite> sprites = new List<Sprite>();

    public int noteGenAmount;
    public int correctNoteAmount;

    private int keyLoop;

    private bool stopped = false;

    private void Start()
    {
        GenerateBeatmap();

        GameObject note = Instantiate(notePrefab,spawnLocation);
        note.GetComponent<NoteScript>().noteKey = beatmap[0];
        foreach (KeyCode key in GameManager.instance.Keys)
            if (key == beatmap[0])
                note.GetComponent<SpriteRenderer>().sprite = sprites[GameManager.instance.Keys.IndexOf(key)];
    }

    private void GenerateBeatmap()
    {
        // for (int i = 0; i < noteGenAmount; i++) 
        // {
        //     KeyCode pickedNote = GameManager.instance.Keys[Random.Range(0,GameManager.instance.Keys.Count)];
        //     beatmap.Add(pickedNote);
        // }

        //Idea so i dont forget or for someone else to build off of
        //Generate like 300-400 notes or smth in the correct order (yhbvft)
        //Then keep adding random notes in random indexes until it gets filled to the noteGenAmount;
        //Maybe will work idrk, idk how else this would work

        for (int i = 0; i < correctNoteAmount; i++) 
        {
            
            if (keyLoop > 5)
                keyLoop = 0;
            beatmap.Add(GameManager.instance.Keys[keyLoop]);
            keyLoop++;

            if (beatmap.Count == correctNoteAmount)
                GenerateWrongNotes();
        }
    }

    private void GenerateWrongNotes()
    {
        for (int i = 0; i < noteGenAmount-correctNoteAmount; i++)
        {
            beatmap.Insert(Random.Range(0,beatmap.Count+1),GameManager.instance.Keys[Random.Range(0,GameManager.instance.Keys.Count)]);
        }
    }

    void Update()
    {
        if (stopped) return;
        beatSpawnTime+= Time.deltaTime;
        if (beatSpawnTime >= GameManager.instance.startingBpm/60f/GameManager.instance.speedMultiplier)
        {
            beatSpawnTime = 0;
            currentNote++;
            if (currentNote >= beatmap.Count)
            {
                stopped = true;
                return;
            }
            GameObject note = Instantiate(notePrefab,spawnLocation);
            
            note.GetComponent<NoteScript>().noteKey = beatmap[currentNote];
            foreach (KeyCode key in GameManager.instance.Keys)
                if (key == beatmap[currentNote])
                    note.GetComponent<SpriteRenderer>().sprite = sprites[GameManager.instance.Keys.IndexOf(key)];
        }
    }
}