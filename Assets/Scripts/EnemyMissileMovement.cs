using UnityEngine;
using System.Collections;

public class EnemyMissileMovement : MonoBehaviour {
    public float speed;
    public GameObject exp;
    public Vector3 mostLeft;
    public Vector3 mostRight;
    private bool destroyed;

    void Start ()
    {
        destroyed = false;
        Vector3 landingSpot = Vector3.Lerp(mostRight, mostLeft, Random.Range(0f, 1f));
        transform.LookAt(landingSpot);
    }
    
	// Update is called once per frame
	void Update ()
    {
        if(!destroyed)
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
	}

    void OnCollisionEnter()
    {
        Instantiate(exp, gameObject.transform.position, exp.transform.rotation);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        destroyed = true;
        gameObject.GetComponent<FadeOut>().Fade();
    }
}
