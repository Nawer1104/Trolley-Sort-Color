using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].ButtonClick(transform.position);
    }
}
