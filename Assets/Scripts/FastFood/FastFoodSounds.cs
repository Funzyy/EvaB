using UnityEngine;

public class FastFoodSounds : MonoBehaviour
{
    public AudioClip extraSound; // Dein Extra-Sound
    public float interval = 10f; // Intervall in Sekunden
    public float volumeSFX = 20;
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource-Komponente hinzufügen und konfigurieren
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = extraSound;
        audioSource.playOnAwake = false;
        audioSource.volume = volumeSFX / 100;

        // Wiederholtes Abspielen starten
        InvokeRepeating(nameof(PlayExtraSound), interval, interval);
    }

    private void PlayExtraSound()
    {
        audioSource.Play();
    }
}
