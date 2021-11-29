using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManage : MonoBehaviour
{
    public static UIManage instance;

    public GameObject gameover;
    public GameObject win;
    public GameObject MenuButton;
    public GameObject Menu;
    public GameObject Store;
    public Text text;
    public Text coins;
    public Bag bag;

    public GameObject level;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void Update()
    {
        GameOver();
        gamewin();
        updatacoins();
    }
    public static void GameOver()
    {
        if(Player.instance.Isdead || Player.instance.HeadCheck)
        {
            instance.gameover.SetActive(true);
            instance.MenuButton.SetActive(false);
            Player.Pause();
        }
    }
    public static void gamewin()
    {
        if (Player.instance.Iswin)
        {
            instance.win.SetActive(true);
            instance.MenuButton.SetActive(false);
            Player.Pause();
            Player.instance.Iswin = false;
        }
    }
    public static void menu()
    {
        instance.Menu.SetActive(true);
        instance.MenuButton.SetActive(false);
        Player.Pause();
    }
    public void openlevel()
    {
        level.SetActive(true);
        Menu.SetActive(false);
        gameover.SetActive(false);

    }
    public void closelevel()
    {
        
        SceneManager.LoadScene(1);
    }
    public static void closemenu()
    {
        instance.Menu.SetActive(false);
        instance.MenuButton.SetActive(true);
    }
    public static void closeGameover()
    {
        instance.gameover.SetActive(false);
        instance.MenuButton.SetActive(true);
    }
    public static void store()
    {
        
        instance.Store.SetActive(true);
    }
    public static void closestore()
    {
        instance.Store.SetActive(false);
    }
    public static void updataintroduce(string mid)
    {
        instance.text.text = mid;
    }

    public static void updatacoins()
    {
        string mid = "½ð±ÒÊý£º";
        instance.coins.text = mid +  instance.bag.coin.ToString();
    }

}
