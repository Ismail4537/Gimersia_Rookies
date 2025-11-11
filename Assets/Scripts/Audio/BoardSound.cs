using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;


public class audio : MonoBehaviour
{

    public AudioClip soundClip;
    public AudioMixerGroup outputAudioMixerGroup;
    public float pitchMultiplier = 2f;
    public float lowPitchMin = 3f;
    public float lowPitchMax = 4f;
    public float highPitchMultiplier = 0.25f;

    private AudioSource sound;
    private bool m_StartedSound;
    public Player player;

    private void StartSound()
    {
        sound = SetUpEngineAudioSource(soundClip);
        m_StartedSound = true;
    }


    private void StopSound()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }

        m_StartedSound = false;
    }


    private void FixedUpdate()
    {

        if ((m_StartedSound && !player.isGrounded) || player.getVelocity().magnitude < 1)
        {
            StopSound();
        }
        if (!m_StartedSound && player.isGrounded && player.getVelocity().magnitude >= 1)
        {
            StartSound();
        }

        if (m_StartedSound)
        {
            float pitch = ULerp(lowPitchMin, lowPitchMax, player.getVelocity().magnitude / player.getMaxSpeed());
            pitch = Mathf.Min(lowPitchMax, pitch);

            sound.pitch = pitch * pitchMultiplier * highPitchMultiplier;
            sound.volume = 1;
        }
    }
    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = outputAudioMixerGroup;
        source.clip = clip;
        source.volume = 0;
        source.spatialBlend = 1;
        source.loop = true;

        source.time = Random.Range(0f, clip.length);
        source.Play();
        return source;
    }
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value) * from + value * to;
    }
}
