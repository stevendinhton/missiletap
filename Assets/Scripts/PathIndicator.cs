using UnityEngine;
using System.Collections;

public class PathIndicator : MonoBehaviour {

    private float turnSpeed;
    private float speed;
    private float proximity;
    private Vector3 target;
    public float scale;
    public float despawnTime;

	// Use this for initialization
	void Start ()
    {
        turnSpeed = gameObject.GetComponentInParent<LaunchToTarget>().turnSpeed * scale;
        speed = gameObject.GetComponentInParent<LaunchToTarget>().speed * scale;
        proximity = gameObject.GetComponentInParent<LaunchToTarget>().proximity;
    }
	
	// Update is called once per frame
	public void DrawTrail()
    {
        target = gameObject.GetComponentInParent<LaunchToTarget>().GetTarget();
        StartCoroutine("Trail");
    }

    IEnumerator Trail()
    {
        float endTime = Time.time + despawnTime;
        while(Time.time < endTime || Vector3.Distance(target, transform.localPosition) > proximity)
        {
            Vector3 direction = target - transform.localPosition;
            Quaternion rotation = Quaternion.LookRotation(direction, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            yield return null;
        }
    }
}
