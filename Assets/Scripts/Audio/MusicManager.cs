using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] private MusicLib musicLib;
    [SerializeField] private AudioSource musicObject;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayMusicTrack(string name, float fadeDuration = 0.5f)
    {
        StartCoroutine(AnimateMusicCrossfade(musicLib.GetTrackByName(name), fadeDuration));
    }

    IEnumerator AnimateMusicCrossfade(AudioClip newClip, float fadeDuration = 0.5f)
    {
        float percent = 0f;
        while (percent < 1f)
        {
            percent += Time.deltaTime + 1 / fadeDuration;
            musicObject.volume = Mathf.Lerp(1f, 0f, percent);
            yield return null;
        }

        musicObject.clip = newClip;
        musicObject.Play();

        percent = 0f;
        while (percent < 1f)
        {
            percent += Time.deltaTime + 1 / fadeDuration;
            musicObject.volume = Mathf.Lerp(0f, 1f, percent);
            yield return null;
        }
    }
}