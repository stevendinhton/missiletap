using UnityEngine;
using System.Collections;

public class MenuBackground : MonoBehaviour {
    public InterceptorManager interceptors; // the interceptor manager
    public Vector3 min;             
    public Vector3 max;         
    public float launchDelay;               // the delay(in secs) between each missile launch, in a volley
    public float volleyDelay;               // the delay(in secs) between each volley


	// Use this for initialization
	void Start ()
    {
        StartCoroutine("LaunchRandomly");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator LaunchRandomly()
    {
        while(true)
        {
            Vector3 target;
            while(interceptors.ready())
            {
                target = new Vector3(Random.Range(min.x,max.x), Random.Range(min.y,max.y), 0);
                interceptors.fire(target);
                yield return new WaitForSeconds(launchDelay);
            }
            yield return new WaitForSeconds(volleyDelay);
        }
    }
}
