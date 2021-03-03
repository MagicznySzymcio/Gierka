using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private float frameLength = 1f;
    private int currentFrame;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameLength)
        {
            timer -= 1f;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[currentFrame];
        }
        
    }
}
