using UnityEngine;
using System.Collections;

public class AutoPlay : MonoBehaviour
{
    public GameObject[] songNotes; //add songnotes or music clips to create Music.
    public float delay = 0.3f;     // time between notes

    public void StartAutoplay()
    {
        StartCoroutine(PlaySong());
    }

    IEnumerator PlaySong()
    {
        for (int i = 0; i < songNotes.Length; i++)
        {
            GameObject note = songNotes[i];

            note.SetActive(false);
            note.SetActive(true);

            yield return new WaitForSeconds(delay);
        }
    }
}
