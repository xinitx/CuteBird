using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grids : MonoBehaviour
{
    public Text text;
    public int order;
    public int price;
    public Bag bag;
    public Text count;
    private bool isbuy = false;
    void Update()
    {
        updataprice();
    }
    public void updatatext()
    {
        UIManage.updataintroduce(text.text);
    }
    public void updataorder()
    {
        GameManage.updataorder(order, price);
    }
    public void updataprice()
    {
        for (int i = 0; i < bag.buy.Count; i++)
        {
            if (bag.buy[i] == order)
            {
                isbuy = true;
                price = 0;
                break;
            }
        }
        if (isbuy)
            count.text = "ÒÑ¹ºÂò";
        else
            count.text = "½ð±Ò£º" + price.ToString();
    } 
}
