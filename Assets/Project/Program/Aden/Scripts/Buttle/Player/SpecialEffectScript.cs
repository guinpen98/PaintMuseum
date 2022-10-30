using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpecialEffectScript : MonoBehaviour
{
    bool special_check = false;
    private int sp_point = 0;
    private int specials = 0;
    private bool red = false;
    private bool green = false;
    private bool blue = false;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public void onRedClick()
    {
        if (special_check == true)
        {
            if (red == false)
            {
                specials++;
                sp_point += 1;
            }
            else
            {
                specials--;
                sp_point -= 1;
            }
            if(specials == 2)
            {
                onSpecial(sp_point);
                special_check = false;
                sp_point = 0;
                specials = 0;
                red = false;
                blue = false;
                green = false;
            }
        }
    }
    public void onGreenClick()
    {
        if (special_check == true)
        {
            if (green == false)
            {
                specials++;
                sp_point += 2;
            }
            else
            {
                specials--;
                sp_point -= 2;
            }
            if (specials == 2)
            {
                onSpecial(sp_point);
                special_check = false;
                sp_point = 0;
                specials = 0;
                red = false;
                blue = false;
                green = false;
            }
        }

    }
    public void onBlueClick()
    {
        if (special_check == true)
        {
            if (blue == false)
            {
                specials++;
                sp_point += 3;
            }
            else
            {
                specials--;
                sp_point -= 3;
            }
            if (specials == 2)
            {
                onSpecial(sp_point);
                special_check = false;
                sp_point = 0;
                specials = 0;
                red = false;
                blue = false;
                green = false;
            }
        }
    }

    private void onSpecial(int sp)
    {
        if(sp == 3)
        {
            Instantiate(effect1, transform.position, Quaternion.identity);
          GameObject target =  GameObject.Find("Main Camera");
            target.SendMessage("shake");


        }
        else if (sp == 4)
        {
            Instantiate(effect2, transform.position, Quaternion.identity);
        }
        else if (sp == 5)
        {
            Instantiate(effect3, new Vector3(0,0,0), Quaternion.identity);

        }
    }
    
   

}
