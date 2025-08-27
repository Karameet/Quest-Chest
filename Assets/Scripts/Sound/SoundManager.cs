using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource AudioSource;

    [SerializeField] private AudioClip uiButtonSound;

    
    public void Init()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayerAudioWith(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.UIButton: PlaySound(uiButtonSound); break;
        }
    }

    private void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayOneShot(audioClip);
    }
}

public enum SoundType
{
    UIButton,
}
