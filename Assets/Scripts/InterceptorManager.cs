using UnityEngine;
using System.Collections;

public class InterceptorManager : MonoBehaviour {
    private int numMissiles;         // the current number of interceptors available to launch    
    public int maxMissiles;          // the maximum number of interceptors that can be held at once
    public Vector3[] locations;      // the locations of where the interceptors will be
    public float spawnheight;        // the height relative to the Vector3 locations where the interceptors will spawn
    public float rearmSpeed;         // animation speed for an interceptor "reloading" and moving into place
    public GameObject intObj;        // the interceptor object
    public GameObject[] interceptors;// the interceptor missiles
    public bool isReloading = false; // whether or not the reloading animation is active
    public float reloadTime;

    // Update is called once per frame
    void Update()
    {
        if(numMissiles == 0 && !isReloading)
            reload();
    }

    public void resume()
    {
        StartCoroutine("reloadProcess");
    }

    void reload()
    {
        for (int i = 0; i < maxMissiles; ++i)
        {
            Destroy(interceptors[i]);
            Vector3 spawnLoc = locations[i] + Vector3.up * spawnheight;
            interceptors[i] = Instantiate(intObj, spawnLoc, intObj.transform.rotation) as GameObject;
        }

        StartCoroutine("reloadProcess");
    }

    public void fire(Vector3 target)
    {
        if(ready())
        { 
            launchInterceptor(interceptors[maxMissiles - numMissiles], target);
            interceptors[maxMissiles - numMissiles] = null;
            --numMissiles;
        }
    }
    
    void launchInterceptor(GameObject interceptor, Vector3 target)
    {
        interceptor.GetComponent<LaunchToTarget>().LockTarget(target);
        interceptor.GetComponent<LaunchToTarget>().launch();
    }

    IEnumerator reloadProcess()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        while (interceptors[0].transform.position != locations[0])
        {
            for (int i = 0; i < interceptors.Length; ++i)
            {
                GameObject inte = interceptors[i];
                inte.transform.position = new Vector3(
                    inte.transform.position.x, 
                    Mathf.Clamp(inte.transform.position.y + rearmSpeed*Time.deltaTime, locations[i].y + spawnheight, locations[i].y), 
                    inte.transform.position.z);
            }
            yield return null;
        }
        numMissiles = maxMissiles;
        isReloading = false;
    }

    public bool ready()
    {
        return (numMissiles > 0);
    }
    
}
