using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
    }
}
