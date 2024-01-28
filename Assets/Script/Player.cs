using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D nhanvat;
    public float tocdo;
    public float traiphai;
    public bool swap=true;
    public Animator anim;
    public float docao;
    private bool ktnhay;
    private bool nhaydoi;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        traiphai = Input.GetAxisRaw("Horizontal");
        nhanvat.velocity = new Vector2(tocdo*traiphai, nhanvat.velocity.y);
        if(swap && traiphai == -1)
        {
            transform.localScale = new Vector2(-5, 5);
            swap = false;
        }
        if (swap==false && traiphai == 1)
        {
            transform.localScale = new Vector2(5, 5);
            swap = true;
        }
        if ((ktnhay && !Input.GetKey(KeyCode.W))|| (ktnhay && !Input.GetKey(KeyCode.Space)))
        {
            nhaydoi = false;
        }
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space))
        {
            if (ktnhay || nhaydoi)
            {
                nhanvat.velocity = new Vector2(nhanvat.velocity.x, docao);
                nhaydoi = !nhaydoi;
                ktnhay = false;
            }
        }
        anim.SetFloat("move", Mathf.Abs(traiphai));
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            ktnhay = true;
    }
}
