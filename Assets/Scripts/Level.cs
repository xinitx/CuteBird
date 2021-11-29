using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level;
    public void changeLevel()
    {
        GameManage.instance.changeleve(level);
    }
}
