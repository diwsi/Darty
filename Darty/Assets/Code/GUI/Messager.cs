using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class Messager : MonoBehaviour
{
    public Text TextObj; 
    
 
    public void ShowMessage(string text)
    {
        gameObject.SetActive(true);
        TextObj.text = text;    
      StartCoroutine(Hide()); 
    }
         
    
    IEnumerator Hide()
    {

        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
