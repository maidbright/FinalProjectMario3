using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float speed = .4f;
    private Vector3 direction;
    public Vector3 Direction { set {  direction = value; } }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed* Time.deltaTime);

    }

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), 2.0f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(); 
    }
}
