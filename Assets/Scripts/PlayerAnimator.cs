using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;

    private Animator animator;

    private void Awake() // only activete when player is moving
    {
        animator = GetComponent<Animator>();
    }

    private void Update() // this is activete walking animation and updete in every frame
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
