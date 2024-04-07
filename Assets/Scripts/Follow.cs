using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform react;

    void Awake()
    {
        react = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        react.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
