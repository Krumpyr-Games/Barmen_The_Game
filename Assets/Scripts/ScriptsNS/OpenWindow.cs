using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{

public bool open_or_close = false; //Check open or close bottom window
public Text text_butt; //Get text for decorate 

public void open_windowUI(){
    if(open_or_close == false){
      transform.localPosition += new Vector3(0,1400,0);
      open_or_close = true;
      text_butt.text = "" + "∨";
    } else {
      transform.localPosition -= new Vector3(0,1400,0);
      open_or_close = false;
      text_butt.text = "" + "∧";
    }
}

}
