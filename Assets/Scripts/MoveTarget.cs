using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public GameObject indicator;
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y + vertical, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);

        if(Input.GetButtonDown("Fire") && GameObject.Find("InterceptorManager").GetComponent<InterceptorManager>().ready())
        {
            Instantiate(indicator, transform.position, transform.rotation);
        }
    }
}
