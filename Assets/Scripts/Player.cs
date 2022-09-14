using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 direction;
    public float gravity = -9.8f;
    public float force = 5f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimaSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector3.up * force;
        }

        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began){
                direction = Vector3.up * force;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimaSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
