using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{
    [SerializeField] RectTransform sizeCell;
    // Position Cell
    public int X {get; private set;}
    public int Y {get ; private set;}
    // The power of a number
    public int Value {get; private set;}
    // The output point on cell
    public int Points => IsEmpty ? 0 :(int)Mathf.Pow(2, Value);
  
    // Checking if Cell is empty 
    public bool IsEmpty => Value == 0;
    
    // Output values
    [SerializeField] private Text points;
    [SerializeField] private Image backgroundColor; 
     

    // Initialization(Setup ) Cell's Fields
    public void SetValue(int x,int y, int value)
    {
        X = x;
        Y = y;
        Value = value;
        // Updating output
        UpdateCell();
    }
    public void SetSize(float SizeCell)
    {
        sizeCell.sizeDelta = new Vector2(SizeCell,SizeCell);
    }
    private void UpdateCell()
    {
        // Updating Text
        points.text = IsEmpty ? "" :Points.ToString();
        // Updating Background Color
        backgroundColor.color = IsEmpty ? Color.grey : ColorManager.Instance.CellColor[Value]  ; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
