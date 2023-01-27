using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter:MonoBehaviour
{
    public Text Text;
    public void SetText(string text)
    {
        Text.text = text;
    }
}

