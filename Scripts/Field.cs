using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    // Field Properties
    //Size in count of cells
    public int FieldSize;
    public int CellSize;
    public int Spacing; 

    [SerializeField] RectTransform rectTransform;
    [SerializeField] Cell CellPrefab;
    private Cell[,] field;
    private void Start() {
        CreateField();
    }
    // Generation Field
    private void GenerateField()
    {
        field = new Cell[FieldSize,FieldSize];
        // Size one Cell with spacing right * on count of all cell + Spacing one cell left 
        float FieldWidth = FieldSize *(CellSize + Spacing )  +Spacing;
        // Set up Size Field
        rectTransform.sizeDelta = new Vector2(FieldWidth,FieldWidth);
        //set up Start position X cell
        float StartX = -(FieldWidth/2) + (CellSize/2) +Spacing;
        //set up Start position Y cell
        float StartY = (FieldWidth/2) - (CellSize/2) - Spacing;

        //Creating Field
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                var cell = Instantiate(CellPrefab,transform, false);
                var position = new Vector2(StartX +(x * (CellSize + Spacing)),StartY -(y * (CellSize + Spacing)) );
                cell.transform.localPosition = position;
                // Write each position cell
                field[x,y] = cell;
                // Setup default preferences
                cell.SetValue(x,y,0);
                cell.SetSize(CellSize);
            }
        }
    }
    private void CreateField()
    {
        //If field has not generated yet. then we call  this method 
        if (field == null)
        {
            GenerateField();
        }
        // If has generated, setup default preferences just
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                field[x,y].SetValue(x,y,0);
            }
        }
    }  
}
