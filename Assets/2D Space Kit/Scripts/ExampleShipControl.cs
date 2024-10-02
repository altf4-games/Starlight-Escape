using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExampleShipControl : MonoBehaviour
{

	public float acceleration_amount = 1f;
	public float rotation_speed = 1f;
	public GameObject turret;
	public float turret_rotation_speed = 3f;
	public float thruster_amt = 1f;
	public float thruster_fill = 100;
	public Image thruster_fill_image;
	public float max_thrust = 2f;

	// Use this for initialization
	void Start()
	{
		max_thrust = PlayerPrefs.GetFloat("ThrusterMaxSpeed", 2f);
		Debug.Log("ThrusterMaxSpeed: " + max_thrust);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Screen.lockCursor = !Screen.lockCursor;

		if (Input.GetKey(KeyCode.Space) && thruster_fill >= 0)
		{
			thruster_amt = max_thrust;
			thruster_fill -= 0.5f;
			thruster_fill = Mathf.Clamp(thruster_fill, 0, 100);
		}
		else
		{
			thruster_amt = 1f;
			thruster_fill += 0.25f;
			thruster_fill = Mathf.Clamp(thruster_fill, 0, 100);
		}
		thruster_fill_image.fillAmount = thruster_fill / 100;
		if (Input.GetKey(KeyCode.W))
		{

			GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration_amount * Time.deltaTime * thruster_amt);



		}
		if (Input.GetKey(KeyCode.S))
		{
			GetComponent<Rigidbody2D>().AddForce((-transform.up) * acceleration_amount * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
		{
			GetComponent<Rigidbody2D>().AddForce((-transform.right) * acceleration_amount * 0.6f * Time.deltaTime);
			//print ("strafeing");
		}
		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
		{
			GetComponent<Rigidbody2D>().AddForce((transform.right) * acceleration_amount * 0.6f * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
		{
			GetComponent<Rigidbody2D>().AddTorque(-rotation_speed * Time.deltaTime);

		}
		if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
		{
			GetComponent<Rigidbody2D>().AddTorque(rotation_speed * Time.deltaTime);

		}
		if (Input.GetKey(KeyCode.C))
		{
			GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * 0.06f * Time.deltaTime);
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * 0.06f * Time.deltaTime);
		}


		if (Input.GetKey(KeyCode.H))
		{
			transform.position = new Vector3(0, 0, 0);
		}
	}

	public void SaveThrusterMaxSpeed()
	{
		PlayerPrefs.SetFloat("ThrusterMaxSpeed", max_thrust);
	}
}
