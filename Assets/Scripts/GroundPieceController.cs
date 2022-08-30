using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPieceController : MonoBehaviour
{
    public bool isColored;

    public void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        isColored = true;

        GameManager.gameManager.CheckComplete();
    }
}
