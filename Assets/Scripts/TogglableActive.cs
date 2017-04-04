using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglableActive : MonoBehaviour {
    
	public void ToggleActive()
    {
        bool nextState = !this.gameObject.activeSelf;
        this.gameObject.SetActive(nextState);
        
    }
}
