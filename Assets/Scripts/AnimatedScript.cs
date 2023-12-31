using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimatedScript : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool useDefualtGameSpeed = false;
    public const float defualtGameSpeed = 5f;
    private int frame = 0;
    private float nextCallTime = 0f;
    private float interval = 0f;
    public bool render = false;
    
    public void Start()
     {
         nextCallTime = Time.time + interval;
     }
     public void Update()
     {
         if (!useDefualtGameSpeed && GameManager.Instance.IsGameOver && frame == sprites.Length - 1) return;
         if(render && Time.time >= nextCallTime)
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

             if (useDefualtGameSpeed)
             {
                 nextCallTime = Time.time + (1f / defualtGameSpeed);
             }
             else
             {
                 nextCallTime = Time.time + (1f / GameManager.Instance.gameSpeed);
             }
         }
         else
         {
             if (!render)
             {
                 frame = 0;
             }
         }
          
     }
}
