using UnityEngine;

public class AnimationNPCStanding : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        // Animator des GameObjects finden
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            int randomIdleIndex = Random.Range(1, 6); // Zufallswert 1 bis 5
            animator.SetInteger("StandingIndex", randomIdleIndex); // Parameter setzen
        }
        else
        {
            Debug.LogError("Animator nicht gefunden!");
        }
    }
}
