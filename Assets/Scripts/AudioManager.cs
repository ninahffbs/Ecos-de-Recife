using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
   [Header("------------Audio Source------------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;
[Header("-----------Audio Source------------")]
    public AudioClip Music;
    public AudioClip pernaRiso;
    public AudioClip firingLama;
    public AudioClip hitTomado;
    public AudioClip Atkprot;
    public AudioClip AtkPerna;
    public AudioClip relogio;

    private void Start()
    {
        musicSource.clip = Music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
