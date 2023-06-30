using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject InfoPanel;

    public void ClosePanel()
    {
        InfoPanel.SetActive(false);
    }

}
