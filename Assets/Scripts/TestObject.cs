using UnityEngine;

public class TestObject : MonoBehaviour
{
    public AudioClip[] testClips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicManager.instance.PlayMusicTrack("test");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void testAudio()
    {
        SFXManager.instance.PlayClip2D("test");
    }
}
