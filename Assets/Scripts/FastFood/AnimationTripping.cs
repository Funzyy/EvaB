using UnityEngine;
using System.Collections;

public class AnimationTripping : MonoBehaviour
{
    private Animator animator; // Animator-Komponente des NPCs
    public float walkingDelay = 5f; // Verzögerung, nach der der NPC anfängt zu gehen (in Sekunden)
    public float stumbleDelay = 5f; // Verzögerung, nach der der NPC stolpert (in Sekunden)
    private bool hasTripped = false; // Kontrollvariable, ob der Ablauf bereits ausgeführt wurde

    private void Start()
    {
        // Animator-Komponente des NPCs holen
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            // Starte die Sequenz des Ablaufs
            StartCoroutine(StartWalkingAndStumble());
        }
        else
        {
            Debug.LogError("Kein Animator auf diesem NPC gefunden!");
        }
    }

    private IEnumerator StartWalkingAndStumble()
    {
        // Warte die vorgegebene Zeit, bevor der NPC zu laufen beginnt
        yield return new WaitForSeconds(walkingDelay);
        
        // Lösen der 'startWalking'-Animation durch einen Trigger
        animator.SetTrigger("startWalking");

        // Warte die vorgegebene Zeit, bevor der NPC stolpert
        yield return new WaitForSeconds(stumbleDelay);

        // Überprüfe, ob der Charakter bereits gestolpert ist
        if (!hasTripped)
        {
            // Lösen der 'stumble'-Animation durch einen Trigger
            animator.SetTrigger("stumble");

            // Markiere den Ablauf als abgeschlossen
            hasTripped = true;

        }
    }
}