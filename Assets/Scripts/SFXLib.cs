using UnityEngine;

[System.Serializable]
public class SFX
{
    public string groupID;
    public AudioClip[] clips;
}

public class SFXLib : MonoBehaviour
{
    public SFX[] sfxs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip GetClipByName(string name)
    {
        foreach (SFX sfx in sfxs)
        {
            if (sfx.groupID == name)
            {
                return sfx.clips[Random.Range(0, sfx.clips.Length)]; // Return a random clip in the group
            }
        }
        return null;
    }
}
