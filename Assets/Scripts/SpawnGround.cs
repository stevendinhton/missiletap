using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {

    public GameObject groundBlock;
    public Vector3 rightStart;
    public Vector3 leftStart;
    public float distance;
    public int length;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < length; ++i)
        {
            Instantiate(groundBlock, rightStart + i * distance*Vector3.right, groundBlock.transform.rotation);
            Instantiate(groundBlock, rightStart + (Vector3.down*+distance) + (i*distance* Vector3.right), groundBlock.transform.rotation);

            Instantiate(groundBlock, leftStart + i * distance * Vector3.left, groundBlock.transform.rotation);
            Instantiate(groundBlock, leftStart + (Vector3.down * +distance) + (i * distance * Vector3.left), groundBlock.transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
