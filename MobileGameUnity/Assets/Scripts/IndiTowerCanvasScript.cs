using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiTowerCanvasScript : MonoBehaviour {



	public void OpenCanvas()
	{
        GetComponent<Canvas>().enabled = true;
	}

    public void CloseCanvas()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
