using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GlobalManager : MonoBehaviour
{
    public static float score;
    private void Start()
    {
        score = 0f;
    }
}
