using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Ground : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    

    // Update is called once per frame
    void Update()
    {
        float speed = 0.1f; //todo: get the actual speed from GameManager
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
