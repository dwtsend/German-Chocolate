using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Texture2D mainCursorTexture;
    private Vector2 mainHotSpot;
    public Texture2D selectionCursorTexture;
    private Vector2 selectionHotSpot;
    private CursorMode cursorMode = CursorMode.Auto;

	// Use this for initialization
	void Start ()
    {
        mainHotSpot = Vector2.zero;
        selectionHotSpot = new Vector2 (16f, 16f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit))
        {            
            switch (rayHit.transform.gameObject.tag)
            {
                case "Unit":
                    Cursor.SetCursor(selectionCursorTexture, selectionHotSpot, cursorMode);
                    break;
                default:
                    Cursor.SetCursor(mainCursorTexture, mainHotSpot, cursorMode);
                    break;
            }
        }

       
	}

}
