using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float gravityModifier = 2;
    private float jumpForce = 12;
    private bool grounded = true;
    
    private bool gameOver = false;

    private Animator anim;

    [SerializeField]
    private ParticleSystem explosionParticle;

    [SerializeField]
    private ParticleSystem dirtParticle;

    [SerializeField]
    private AudioClip jumpSound;
    
    [SerializeField]
    private AudioClip crashSound;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground" && !gameOver)
        {
            grounded = true;
            dirtParticle.Play();
        }
        if(other.gameObject.tag == "Obstacle" && !gameOver)
        {
            audioSource.PlayOneShot(crashSound);
            gameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
        }
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
