using UnityEngine;
using System.Collections;


public class AnimationTripping : MonoBehaviour
{
    private Animator animator; // Animator des NPCs
    public float walkingDelay = 5f; // Verzögerung, nach der der NPC anfänt zu gehen (in Sekunden)
    public float stumbleDelay = 5f; // Verzögerung, nach der der NPC stolpert (in Sekunden)


    private void Start()
    {
        // Animator-Component holen
        animator = GetComponent<Animator>();

        if (animator != null)
        {

            // Starte Coroutine, um nach der Verzögerung den 'stumble'-Parameter zu setzen
            StartCoroutine(startWalking());
            StartCoroutine(stumble());
        }
        else
        {
            Debug.LogError("Kein Animator auf diesem NPC gefunden!");
        }
    }

    private IEnumerator startWalking()
    {
        // Warte die angegebene Zeit (z.B. 5 Sekunden)
        yield return new WaitForSeconds(walkingDelay);

        // Setze den 'stumble'-Parameter auf true, um die Übergang zu 'tripping' auszulösen
        animator.SetBool("startWalking", true);
    }

    private IEnumerator stumble()
    {
        // Warte die angegebene Zeit (z.B. 5 Sekunden)
        yield return new WaitForSeconds(stumbleDelay);

        // Setze den 'stumble'-Parameter auf true, um die Übergang zu 'tripping' auszulösen
        animator.SetBool("stumble", true);
    }

}
