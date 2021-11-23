using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletBehavior : MonoBehaviour
{
	[SerializeField] private float speedUp = 5f;
	Rigidbody _rb;
	public float onescreenDelay = 3f;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Vector3 forwardUp = this.transform.position + transform.forward * speedUp * Time.fixedDeltaTime;
		_rb.transform.position = forwardUp;
		Destroy(this.gameObject, onescreenDelay);
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "meteor")
		{
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
		}
	}
}
