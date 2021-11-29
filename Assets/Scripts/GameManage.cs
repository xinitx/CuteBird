using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public Bag bag;
    public SpriteRenderer player;
    public GameObject store;
    private int order;
    private int price;
    private bool ischange = true;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        order = bag.use;
    }
    private void Update()
    {
        if (ischange)
            updataplayer();
    }
    public static void restart()
    {
        SceneManager.LoadScene(1);
        UIManage.closemenu();
        UIManage.closeGameover();
        
    }
    public static void Exit()
    {
        Application.Quit();
    }
    public static void updataorder(int mid1, int mid2)
    {
        instance.order = mid1;
        instance.price = mid2;
        print(instance.order);
    }
    public static void buy()
    {
        if(instance.bag.coin >= instance.price)
        {
            instance.bag.buy.Add(instance.order);
            instance.bag.coin -= instance.price;
        }
    }
    public void use()
    {
        bool isbuy = false;
        for(int i = 0; i < bag.buy.Count; i++)
        {
            if(bag.buy[i] == order )
            {
                isbuy = true;
            }
        }
        if(isbuy)
        {
            //player.sprite = store.transform.GetChild(order).gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().sprite;
            ischange = true;
            bag.use = order;
        }

    }
    void updataplayer()
    {
        player.sprite = store.transform.GetChild(order).gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().sprite;
        ischange = false;
    }
    public void changeleve(int level)
    {
        bag.Level = level;
    }
}
