using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWorlds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.Instance.maincanvas.activeSelf)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
               
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "DrakeWorld")
                    {
                        if ((GameManager.Instance.drakeActive) && (GameManager.Instance.tokens >= 1) && (!GameManager.Instance.drakepaypanel.activeSelf))
                        {
                            GameManager.Instance.UpdatePanelPaymentDrake();
                            GameManager.Instance.UpdateTokens();
                        }
                        else if(GameManager.Instance.drakeActive == false)
                        {
                            GameManager.Instance.UpdateBlockedPanel();
                        }
                        else if(GameManager.Instance.tokens <= 0)
                        {
                            GameManager.Instance.UpdatePoorPanel();
                        }
                        
                    }
                    else if((hitInfo.transform.gameObject.tag == "ShipWorld"))
                    {
                        if ((GameManager.Instance.shipActive) && (GameManager.Instance.tokens >= 1) && (!GameManager.Instance.shippaypanel.activeSelf))
                        {
                            GameManager.Instance.UpdatePanelPaymentShip();
                            GameManager.Instance.UpdateTokens();
                        }
                        else if (GameManager.Instance.shipActive == false)
                        {
                            GameManager.Instance.UpdateBlockedPanel();
                        }
                        else if (GameManager.Instance.tokens <= 0)
                        {
                            GameManager.Instance.UpdatePoorPanel();
                        }
                        Debug.Log("ShipHEHE");
                    }
                    else if ((hitInfo.transform.gameObject.tag == "DronWorld"))
                    {
                        if ((GameManager.Instance.dronActive) && (GameManager.Instance.tokens >= 1) && (!GameManager.Instance.dronpaypanel.activeSelf))
                        {
                            GameManager.Instance.UpdatePanelPaymentDron();
                            GameManager.Instance.UpdateTokens();
                        }
                        else if (GameManager.Instance.dronActive == false)
                        {
                            GameManager.Instance.UpdateBlockedPanel();
                        }
                        else if (GameManager.Instance.tokens <= 0)
                        {
                            GameManager.Instance.UpdatePoorPanel();
                        }
                        Debug.Log("DronHEHE");
                    }
                    
                }
                else
                {
                    Debug.Log("No Hit");
                    if(GameManager.Instance.drakepaypanel.activeSelf)
                    {
                        GameManager.Instance.UpdatePanelPaymentDrake();
                         
                    }
                    if(GameManager.Instance.shippaypanel.activeSelf)
                    {
                        GameManager.Instance.UpdatePanelPaymentDrake();
                    }
                    if (GameManager.Instance.dronpaypanel.activeSelf)
                    {
                        GameManager.Instance.UpdatePanelPaymentDron();
                    }
                    if (GameManager.Instance.blockedPanel.activeSelf)
                    {
                        GameManager.Instance.UpdateBlockedPanel();
                    }
                    if(GameManager.Instance.poorPanel.activeSelf)
                    {
                        GameManager.Instance.UpdatePoorPanel();
                    }
                    if(GameManager.Instance.qrScanner.activeSelf)
                    {
                        GameManager.Instance.UpdateQRScanner();
                    }
                }

                Debug.Log("Mouse is down");
            }
        }
    }
}
