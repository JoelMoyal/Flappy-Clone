using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver)
        {
            rigid.velocity = Vector2.zero;
        }
    }
}
