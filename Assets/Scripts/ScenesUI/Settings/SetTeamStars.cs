using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTeamStars : MonoBehaviour
{
    public void setTeamStars()
    {
        int numberOfStars = int.Parse(this.name[0].ToString());
        Transform parentTransform = this.transform.parent;
        foreach(Transform child in parentTransform)
        {
            if(child.name.Contains("Button"))
                continue;
            int childStars = int.Parse(child.name[0].ToString());
            if(childStars <= numberOfStars)
                child.gameObject.GetComponent<Toggle>().isOn = true;
            else
                child.gameObject.GetComponent<Toggle>().isOn = false;
        }
    }
}
