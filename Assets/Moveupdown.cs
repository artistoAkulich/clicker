
using UnityEngine;

public class Moveupdown : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Moveupdown", true);
    }
}