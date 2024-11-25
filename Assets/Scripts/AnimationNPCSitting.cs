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
            int randomIdleIndex = Random.Range(1, 4);
            animator.SetInteger("SittingIndex", randomIdleIndex); // Parameter setzen

            // Zufälligen Wert für Cycle Offset generieren (zwischen 0 und 1)
            float randomCycleOffset = Random.Range(0f, 1f);

            // Den Cycle Offset-Parameter im Animator setzen
            animator.SetFloat("cycleOffset", randomCycleOffset);

        }
        else
        {
            Debug.LogError("Animator nicht gefunden!");
        }
    }
}
