using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScript : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int frame;
    private float nextCallTime = 0f;
    private float interval = 0f; 

    // private void OnEnable()
    // {
    //     Invoke(nameof(Animate), 0f);
    // }
    // private void OnDisable()
    // {
    //     CancelInvoke();   
    // }
    // private void Animate()
    // {
    //     ++frame;
    //     if(frame >= sprites.Length)
    //     {
    //         frame = 0;
    //     }
    //     if(frame >= 0 && frame < sprites.Length)
    //     {
    //         spriteRenderer.sprite = sprites[frame];
    //     }
    //     Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    // }
    public void Start()
    {
        nextCallTime = Time.time + interval;
    }
    public void Update()
    {
        if(Time.time >= nextCallTime)
        {
            ++frame;
            if(frame >= sprites.Length)
            {
                frame = 0;
            }
            if(frame >= 0 && frame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[frame];
            }
            nextCallTime = Time.time + 1f / GameManager.Instance.gameSpeed;
        }
         
    }
}
