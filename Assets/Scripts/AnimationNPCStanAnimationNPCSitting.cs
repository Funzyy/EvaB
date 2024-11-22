using UnityEngine;

public class AnimationNPCSitting : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        // Animator des GameObjects finden
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            int randomIdleIndex = Random.Range(1, 3);
            animator.SetInteger("SittingIndex", randomIdleIndex); // Parameter setzen
        }
        else
        {
            Debug.LogError("Animator nicht gefunden!");
        }
    }
}
