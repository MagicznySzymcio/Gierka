using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer -= 1f;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            gameObject.GetComponent<SpriteRenderer>().sprite = frameArray[currentFrame];
        }
        
    }
}
