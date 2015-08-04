using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin = -6f;
	public float xMax = 6f;
	public float zMin = -4f;
	public float zMax = 8f;
}

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public float speed = 4.5f;
    public float tilt = 3f;
    public Boundary boundary;
	public GameObject bolt = null;
	public Transform shotSpawn;
	public float fireRate = 1f;

	private float nextFire;

    void Awake()
    {
		rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
		if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
		}
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
