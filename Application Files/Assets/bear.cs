using UnityEngine;
using Random = UnityEngine.Random;

public class Bear : MonoBehaviour {

    protected Animator Animator;
    protected Rigidbody Rigidbody;
    protected Vector3 Target;

    // Use this for initialization
    void Start ()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        Target = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Animator.SetFloat("Speed", Rigidbody.velocity.magnitude);

        if(Vector3.Distance(Target, transform.position) < 30f)
            Target = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y) * 80f;

        transform.LookAt(_toGround(transform.position + ((Rigidbody.velocity.magnitude < 1f)?Vector3.forward:Rigidbody.velocity) * 2000f), Vector3.up);
        Rigidbody.AddForce(_toGround((Target - transform.position).normalized) * 10f, ForceMode.Force);
        Animator.SetFloat("Speed", Mathf.Clamp(Rigidbody.velocity.magnitude,0f,1f));


    }

    private Vector3 _toGround(Vector3 input)
    {
        input = new Vector3(input.x, 0f, input.z);
        return input;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Target, 1);
    }
}
