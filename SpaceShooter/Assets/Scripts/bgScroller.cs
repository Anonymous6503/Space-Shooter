using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    [SerializeField] Material material;

    [SerializeField] Vector2 offset;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
