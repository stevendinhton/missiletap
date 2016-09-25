using UnityEngine;
using System.Collections;

public class LaunchToTarget : MonoBehaviour {

    public float turnSpeed;     // turn speed
    public float speed;
    public float proximity;     // the distance to the target at which the missile will "detonate"
    public bool launched;
    public GameObject exp;      // the explosion object
    public GameObject particle;
    private Vector3 target;     // pointer
    
    public void LockTarget (Vector3 location)
    {
        target = location;
    }

    public Vector3 GetTarget()
    {
        return target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (launched)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;

            Vector3 direction = target - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

            if (Vector3.Distance(target, transform.position) <= proximity)
            {
                explode();
            }
        }
	}

    void OnCollisionEnter()
    {
        if(launched)
        {
            explode();
        }
    }

    void explode()
    {
        launched = false;
        Instantiate(exp, transform.position, transform.rotation);
        gameObject.GetComponent<FadeOut>().Fade();
    }

    public void launch()
    {
        launched = true;
        StartCoroutine("LineToTarget");
    }

    IEnumerator LineToTarget()
    {
        while(launched)
        {
            gameObject.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, GetTarget() });
            yield return null;
        }
    }
}
