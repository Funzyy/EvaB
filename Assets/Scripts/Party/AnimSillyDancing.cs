using UnityEngine;
using System.Collections;

public class AnimSillyDancing : MonoBehaviour
{
    private Animator animator; // Animator des NPCs
    public float dancingDelay = 5f; // Verz�gerung, nach der der NPC anf�ngt zu tanzen (in Sekunden)
    public float standingDelay = 5f; // Verz�gerung, nach der der NPC wieder stehen bleibt (in Sekunden)

    private void Start()
    {
        // Animator-Component holen
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetBool("isStanding", true);
            animator.SetBool("isDancing", false);

            // Starte Coroutine, um Animationen auszul�sen
            StartCoroutine(DanceAndStop());
        }
        else
        {
            Debug.LogError("Kein Animator auf diesem NPC gefunden!");
        }
    }

    private IEnumerator DanceAndStop()
    {
        yield return new WaitForSeconds(dancingDelay);

        animator.SetBool("isDancing", true);
        animator.SetBool("isStanding", false);

        yield return new WaitForSeconds(standingDelay);

        animator.SetBool("isStanding", true);
        animator.SetBool("isDancing", false);
    }
}
