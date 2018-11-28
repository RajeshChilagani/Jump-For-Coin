using UnityEngine;
using System.Collections;

public class fox : MonoBehaviour {
    public  float mspeed = 1f;
    bool faceRight = true;
    Animator an;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask theGround;
    public float Jumpspeed = 700f;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        an = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, theGround);
        an.SetBool("ground", grounded);
        an.SetFloat("Vspeed", GetComponent<Rigidbody2D>().velocity.y); 
        float move = Input.GetAxis("Horizontal");
        an.SetFloat("speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * mspeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !faceRight)
            Flip();
        else if (move < 0 && faceRight)
            Flip();
	}
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            an.SetBool("ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jumpspeed));
        }
    }
    
    void Flip()
    {
       faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        if (col.gameObject.name=="coin")
        {
            audio.Play();
            Destroy(col.gameObject);
        }
    }


}
