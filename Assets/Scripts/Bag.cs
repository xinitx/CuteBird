using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Bag/new Bag")]
public class Bag : ScriptableObject
{
    // Start is called before the first frame update
    public int coin;
    public List<int> buy = new List<int>();
    public int use = 0;
    public int Level = 0;
    public List<Vector2> first= new List<Vector2>();
    
}
