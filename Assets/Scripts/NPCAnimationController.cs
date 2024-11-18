using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

public class NPCAnimationController : MonoBehaviour
{
    // Declarations for AnimationChangeDefault
    Animator animator;
    float waitingTime;
    bool animationChange;
    public float waitingTimeUpperLimit;
    public float waitingTimeLowerLimit;
    private float timer = 0f;
    private int pickAnimation = 0;

    // Declarations for AnimationChange+-
    public float animDelay;
    //static float randomValue;
    private int randomValue;
    //TODO: create variable for random timespan to wait before triggering +- anims
    // Button A of the right Controller
    private UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button rightA = UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button.PrimaryButton;
    private UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button rightB = UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button.SecondaryButton;


    public void triggerPositiveAnimations()
    {
        StartCoroutine(WaitAndContinue());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initializing for AnimationChangeDefault
        waitingTime = UnityEngine.Random.Range(10f, 90f);
        animationChange = false;
        animator = GetComponent<Animator>();

        // Initializing for AnimationChange+-
        animDelay = 1;
        // ob der NPC die Animation abspielt, könnte man auch abhängig machen von der Range an sich..
        // z.B. Range 1 - 10 würde nur jeden 3. NPCs zur Animation zwingen (statistisch gesehen)
        // eigentlich werden Reaktionen nur bei 1, 2 oder 3 getriggert, aber es sollen nicht alle NPCs gleichzeitig Reaktionen abspielen
        randomValue = UnityEngine.Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        //if animationChange false and current state is not SittingLegsCrossed, increase timer
        //if animation state LegsCrossed, the animation will be playing for another timer period, other
        //states will imidiately change back to default state, when animation is done
        if (CheckButtonPress(rightA) || Input.GetKeyDown("p"))
        {
            StartCoroutine(WaitAndContinue());
        }

        // Triggering negative Reaction is not intended to be possible in the endgame
        if (CheckButtonPress(rightB) || Input.GetKeyDown("n"))
        {
            animator.SetBool("playPositiveAnim", false);
            animator.SetInteger("trigger+-animation", randomValue);
            randomValue = UnityEngine.Random.Range(1, 4);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AnimSittingClapping") || animator.GetCurrentAnimatorStateInfo(0).IsName("AnimSittingDisaproval")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("AnimSittingClapping3") || animator.GetCurrentAnimatorStateInfo(0).IsName("AnimSittingYelling")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("AnimSittingDisbelief"))
        {
            animator.SetInteger("trigger+-animation", 0);
        }



        if(!animationChange && !animator.GetCurrentAnimatorStateInfo(0).IsName("SittingLegsCrossed"))
        {
            timer += Time.deltaTime;
            //if timer >= waitingTime, set animationChange true, reset timer + waitingTime and pick random Animation
            if (timer >= waitingTime)
            {
                animator.SetBool("animationChange", true);
                animationChange = true;
                timer = 0f;
                waitingTime = UnityEngine.Random.Range(10f, 90f);
                pickAnimation = UnityEngine.Random.Range(0, 4);

                switch (pickAnimation)
                {
                    case 0: animator.SetBool("legsCrossed", true);
                    break;
                    case 1: animator.SetBool("sittingNervous", true);
                    break;
                    case 2: animator.SetBool("sittingTalking", true);
                    break;
                    case 3: animator.SetBool("sittingTalking2", true);
                    break;
                    default:
                    break;
                }
            }
        }

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("SittingIdle1"))
        {
            animator.SetBool("animationChange", false);
            animationChange = false;
        }
        //if waiting time is reached, set bool false and reset timer, back to default animation state
        //timer now triggers next animation change again, instead of defining the time Legs Crossed animtion is played
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SittingLegsCrossed") && timer >= waitingTime)
        {
            animator.SetBool("legsCrossed", false);
            timer = 0f;
        }
        //if waiting time is not reached, stay in SittingLegsCrossed and increase the timer
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SittingLegsCrossed") && timer < waitingTime)
        {
            //animator.SetBool("legsCrossed", false);
            animator.SetInteger("trigger+-animation", 0);
            timer += Time.deltaTime;
        }


        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SittingNervous"))
        {
            animator.SetInteger("trigger+-animation", 0);
            animator.SetBool("sittingNervous", false);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SittingTalking2"))
        {
            animator.SetInteger("trigger+-animation", 0);
            animator.SetBool("sittingTalking2", false);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SittingTalking"))
        {
            animator.SetInteger("trigger+-animation", 0);
            animator.SetBool("sittingTalking", false);
        }
    }

    private bool CheckButtonPress(UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button button)
    {
        // Right controller
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        bool isPressed;

        if (device != null && device.TryGetFeatureValue(new InputFeatureUsage<bool>(button.ToString()), out isPressed))
        {
            return isPressed;
        }
        return false;
    }

    IEnumerator WaitAndContinue()
    {
        // Warte 2 Sekunden
        yield return new WaitForSeconds(UnityEngine.Random.Range(waitingTimeLowerLimit, waitingTimeUpperLimit));
        
        animator.SetBool("playPositiveAnim", true);
        animator.SetInteger("trigger+-animation", randomValue);
        randomValue = UnityEngine.Random.Range(1, 4);
    }
}
