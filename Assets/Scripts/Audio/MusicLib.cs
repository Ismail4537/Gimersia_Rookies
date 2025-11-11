using UnityEngine;

[System.Serializable]
public class MusicTrack
{
    public string trackName;
    public AudioClip clip;
}

public class MusicLib : MonoBehaviour
{
    public MusicTrack[] musicTracks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip GetTrackByName(string name)
    {
        foreach (MusicTrack track in musicTracks)
        {
            if (track.trackName == name)
            {
                return track.clip;
            }
        }
        return null;
    }
}
