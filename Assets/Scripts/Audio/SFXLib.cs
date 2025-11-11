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
                return sfx.clips[Random.Range(0, sfx.clips.Length)];
            }
        }
        return null;
    }

    public AudioClip GetClipSpecific(string groupName, int index)
    {
        foreach (SFX sfx in sfxs)
        {
            if (sfx.groupID == groupName)
            {
                if (index >= 0 && index < sfx.clips.Length)
                {
                    return sfx.clips[index];
                }
            }
        }
        return null;
    }
}
