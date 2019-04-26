using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballMovement : MonoBehaviour
{
	public ParticleSystem Particle;
	public ParticleSystem Particle2;
	public ParticleSystem ParticleFireTree;
	public ParticleSystem ParticleFireTree2;
	public ParticleSystem ParticleFireTree3;
	public ParticleSystem ParticleFireTree4;
	public float speed = 1;
	public int powerupRespawnTimer = 5;
	private Rigidbody rb;
	public GameObject prefabFire;
	public GameObject prefabIce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		Particle.Stop();
		Particle2.Stop();
		ParticleFireTree.Stop();
		ParticleFireTree2.Stop();
		ParticleFireTree3.Stop();
		ParticleFireTree4.Stop();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) {
         Instantiate(prefabFire);
      }
        float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontalMovement,0,verticalMovement);
		rb.AddForce(movement * speed);
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("powerup"))//fire
		{
			other.gameObject.SetActive(false);
			Particle2.Stop();
			Particle.Play();
			Invoke("SpawnPowerup", powerupRespawnTimer);
		}
		if (other.gameObject.CompareTag("powerupice"))//ice
		{
			other.gameObject.SetActive(false);
			Particle.Stop();
			Particle2.Play();
			Invoke("SpawnPowerupIce", powerupRespawnTimer);
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("tree"))
		{
			if (Particle.isPlaying)
				ParticleFireTree.Play();
			else if (Particle2.isPlaying)
				ParticleFireTree.Stop();
		}
		if (other.gameObject.CompareTag("tree2"))
		{
			if (Particle.isPlaying)
				ParticleFireTree2.Play();
			else if (Particle2.isPlaying)
				ParticleFireTree2.Stop();
		}
		if (other.gameObject.CompareTag("tree3"))
		{
			if (Particle.isPlaying)
				ParticleFireTree3.Play();
			else if (Particle2.isPlaying)
				ParticleFireTree3.Stop();
		}
		if (other.gameObject.CompareTag("tree4"))
		{
			if (Particle.isPlaying)
				ParticleFireTree4.Play();
			else if (Particle2.isPlaying)
				ParticleFireTree4.Stop();
		}
	}
	
	void SpawnPowerup()
	{
		Instantiate(prefabFire);
		prefabFire.SetActive(true);
	}
	
	void SpawnPowerupIce()
	{
		Instantiate(prefabIce);
		prefabIce.SetActive(true);
	}
}
