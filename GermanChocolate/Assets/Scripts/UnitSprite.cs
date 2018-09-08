using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.AI;

public class UnitSprite : MonoBehaviour
{
    private NavMeshAgent parentAgent;

    //Animation Components
    private SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idleFront;
    public AnimationReferenceAsset idleBack;
    public AnimationReferenceAsset idleRight;  
    public AnimationReferenceAsset runFront;
    public AnimationReferenceAsset runBack;
    public AnimationReferenceAsset runRight;
    private AnimationReferenceAsset targetAnimation;
    private AnimationReferenceAsset previousAnimation;

    private void Awake()
    {
      
    }
    // Use this for initialization
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        parentAgent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Force our sprite to always face the camera (Billboarding)
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
                
        UpdateAnimation(parentAgent.velocity);
    }

    //Function to set animation state based on facing direction
    private void UpdateAnimation(Vector3 currentVelocity)
    {
        float horizontal = currentVelocity.x;
        float vertical = currentVelocity.z;

        if (Mathf.Abs(horizontal) <= 0.1f && Mathf.Abs(vertical) <= 0.1f)
        {
            switch (skeletonAnimation.AnimationName)
            {
                case "runFront":
                    targetAnimation = idleFront;
                    break;
                case "runRight":
                    targetAnimation = idleRight;
                    break;
                case "runBack":
                    targetAnimation = idleBack;
                    break;
                default:
                    targetAnimation = idleFront;
                    break;
            }

        }

        else
        {
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                targetAnimation = runRight;
                if (horizontal < 0)
                    skeletonAnimation.Skeleton.FlipX = true;
                else
                    skeletonAnimation.skeleton.FlipX = false;
            }
            else if (Mathf.Abs(horizontal) < Mathf.Abs(vertical))
            {
                if (vertical > 0)
                    targetAnimation = runBack;
                if (vertical < 0)
                    targetAnimation = runFront;
            }
        }

        if (targetAnimation != previousAnimation)
            skeletonAnimation.AnimationState.SetAnimation(0, targetAnimation, true);

        previousAnimation = targetAnimation;

    }
}
