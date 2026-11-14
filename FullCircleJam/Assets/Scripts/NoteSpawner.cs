using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnLocation;
    private float beatSpawnTime;
    private int currentNote = 0;
    public List<KeyCode> beatmap = new List<KeyCode>();
    public List<Color> colors = new List<Color>();

    private void Start()
    {
        GameObject note = Instantiate(notePrefab,spawnLocation);
        note.GetComponent<NoteScript>().noteKey = beatmap[0];
        foreach (KeyCode key in GameManager.instance.Keys)
            if (key == beatmap[0])
                note.GetComponent<SpriteRenderer>().color = colors[GameManager.instance.Keys.IndexOf(key)];
    }

    void Update()
    {
        beatSpawnTime+= Time.deltaTime;
        if (beatSpawnTime >= GameManager.instance.startingBpm/60f/GameManager.instance.speedMultiplier)
        {
            beatSpawnTime = 0;
            currentNote++;
            if (currentNote >= beatmap.Count)
                currentNote = 0;
            GameObject note = Instantiate(notePrefab,spawnLocation);
            
            note.GetComponent<NoteScript>().noteKey = beatmap[currentNote];
            foreach (KeyCode key in GameManager.instance.Keys)
                if (key == beatmap[currentNote])
                    note.GetComponent<SpriteRenderer>().color = colors[GameManager.instance.Keys.IndexOf(key)];
        }
    }
}