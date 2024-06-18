using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{

    private Animator ChapterAnimation;
    // Start is called before the first frame update
    void Start()
    {
        ChapterAnimation = GetComponent<Animator>();
        ChapterAnimation.Play("ChapterFadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
