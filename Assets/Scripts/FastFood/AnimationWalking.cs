using UnityEngine;
using System.Collections;

public class AnimationWalking : MonoBehaviour
{
    private Animator animator; // Animator des NPCs
    public float walkingDelay = 5f; // Verzögerung, nach der der NPC anfängt zu gehen (in Sekunden)
    public float standingDelay = 5f; // Verzögerung, nach der der NPC wieder stehen bleibt (in Sekunden)

    private void Start()
    {
        // Animator-Component holen
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetBool("isStanding", true);
            animator.SetBool("isWalking", false);

            // Starte Coroutine, um Animationen auszulösen
            StartCoroutine(WalkAndStop());
        }
        else
        {
            Debug.LogError("Kein Animator auf diesem NPC gefunden!");
        }
    }

    private IEnumerator WalkAndStop()
    {
        yield return new WaitForSeconds(walkingDelay);

        animator.SetBool("isWalking", true);
        animator.SetBool("isStanding", false);

        yield return new WaitForSeconds(standingDelay);

        animator.SetBool("isStanding", true);
        animator.SetBool("isWalking", false);
    }
}
