using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
	
	public GameObject pinball;
	public int springForce = 1200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject == pinball)
		{
			pinball.GetComponent<Rigidbody>().AddExplosionForce(springForce, transform.position, 1);
		}
	}
}


