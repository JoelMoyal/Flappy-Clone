using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;

    private bool isDead = false;
    private Animator animator;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>(); }

    // Update is called once per frame
    void Update()
    {
        if(!isDead) // isDead == false
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Flap");
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
