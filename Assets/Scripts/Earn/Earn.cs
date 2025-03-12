using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Earn : MonoBehaviour
{
    protected BoxCollider2D collider2D;
    protected Animator animator;
    public BoxCollider2D e_BoxCollider2D { get { return collider2D = collider2D ?? GetComponent<BoxCollider2D>(); } }
    public Animator e_Animator { get { return animator = animator ?? GetComponent<Animator>(); } }

    public abstract void CreationOfPrefab();
}
