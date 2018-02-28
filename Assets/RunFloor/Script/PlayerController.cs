using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float jumpForce = 300f;
	public float gravityNormal = 1;
	public float gravityJump = 0.3f;
	public LayerMask layerGround;
	[Tooltip("Spawn explosion fx when hit trap")]
	public GameObject ExplosionFx;
	[Header("Sound")]
	public AudioClip jumpSound;
	public AudioClip failSound;
	public AudioClip scoreSound;

	private float speedRun = 1;
	private Rigidbody2D rig;
	private bool fail = false;
	private bool isGrounded = false;


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, -0.1f);
		rig = GetComponent<Rigidbody2D> ();
		speedRun = GameManager.Speed;
		if (transform.position.x > 0)	//when Floor.cs spawn new Player in scene, this Player will be placed to right or left of the screen, so we check it position to make it move right or left
			speedRun *= -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fail) {
			if (Input.GetMouseButtonDown (0) && isGrounded) {		//only jump when the player on the ground
				SoundManager.PlaySfx (jumpSound);
				rig.velocity = Vector2.zero;
				rig.gravityScale = gravityJump;		//set new gravity to the player when he jump
				rig.AddForce (new Vector2 (0, jumpForce));
			}
			if (Input.GetMouseButtonUp (0)) {
				rig.gravityScale = gravityNormal;	
			}
		}
	}

	void FixedUpdate(){
		if (!fail)
			transform.Translate (new Vector3 (speedRun * Time.fixedDeltaTime, 0, 0));

		//Check player on the ground
		if (Physics2D.CircleCast (transform.position, 0.1f, Vector2.down, 0.5f, layerGround))
			isGrounded = true;
		else
			isGrounded = false;

	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Trap")){	//detect collide with trap object
			fail = true;
			SoundManager.PlaySfx (failSound);
			GameManager.instance.GameOver ();
			Instantiate (ExplosionFx, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Finish")) {
			SoundManager.PlaySfx (scoreSound);
			GameManager.Score++;
			other.gameObject.SendMessage ("Pass", SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
		else if (other.gameObject.CompareTag ("Point")) {
			;
		}
	}
}
