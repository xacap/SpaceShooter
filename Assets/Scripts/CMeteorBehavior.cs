using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeteorBehavior : MonoBehaviour
{
	[SerializeField] private float speedUp = 5f;
	[SerializeField] public float onescreenDelay = 10f;
	[SerializeField] int damage = 40;
	Rigidbody _rb;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}
    private void Start()
    {
		_rb.velocity = transform.forward * -speedUp;
	}

    void Update()
	{
		Destroy(this.gameObject, onescreenDelay);
	}
	
	void OnTriggerEnter(Collider collision)
	{
		CPlayerController player = collision.GetComponent<CPlayerController>();

		if (player != null && collision.gameObject.tag == "player")
		{
			Destroy(gameObject);
			player.TakeDamage(damage);
		}
	}
}
