using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceenConfig : MonoBehaviour
{ 

  public Transform mainGame;
  ScreenManag _mgr;


  private void Start()
  {
        _mgr = ScreenManag.Instance;

        _mgr.Push(new ScreenGO(mainGame));
   }

  private void Update()
  {

        
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            var s = Instantiate(Resources.Load<ScreenPause>("CanvasPause")); 
            _mgr.Push(s);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            _mgr.Pop();
        }
    }
}
