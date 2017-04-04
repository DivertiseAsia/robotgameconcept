using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableActive : MonoBehaviour {

    public string cow;
	public bool ToggleActive()
    {
        bool nextState = !this.gameObject.activeSelf;
        this.gameObject.SetActive(nextState);

        return nextState;
    }
}
