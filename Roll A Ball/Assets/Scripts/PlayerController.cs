using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		this.SetCountText ();
		winText.text = "";
	}
	
	void FixedUpdate()
	{
		float moveHorizontal;
		float moveVertical;
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		} else {
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}
			
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count += 1;
			this.SetCountText ();
		}
	}

	private void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You win";
		}
	}
}
