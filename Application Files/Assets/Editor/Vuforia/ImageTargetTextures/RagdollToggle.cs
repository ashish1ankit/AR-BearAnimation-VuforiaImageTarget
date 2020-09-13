using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggle : MonoBehaviour {

    protected Animator Animator;
    protected Rigidbody Rigidbody;
    protected BoxCollider BoxCollider;
    protected Bear Bear;

    protected Collider[] ChildrenCollider;
    protected Rigidbody[] ChildrenRigidbody;

    // Use this for initialization
    void Awake ()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
        Bear = GetComponent<Bear>();

        ChildrenCollider = GetComponentsInChildren<Collider>();
        ChildrenRigidbody = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {
        RagdollActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RagdollActive(bool active)
    {
        //children
        foreach (var collider in ChildrenCollider)
            collider.enabled = active;
        foreach (var rigidbody in ChildrenRigidbody)
        {
            rigidbody.detectCollisions = active;
            rigidbody.isKinematic = !active;
        }

        //root
        Animator.enabled = !active;
        Rigidbody.detectCollisions = !active;
        Rigidbody.isKinematic = active;
        BoxCollider.enabled = !active;
        Bear.enabled = !active;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Ball>() != null)
            RagdollActive(true);
    }

}
