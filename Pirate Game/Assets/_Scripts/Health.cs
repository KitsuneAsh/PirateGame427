using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private float CurrentHealthValue;
    [SerializeField]
    private float MaxHealthValue = 100;

    //private int health 
    //{
    //    get 
    //    {
    //        return value;
    //    }
    //    set 
    //    {
    //        value = health;
    //    }
    //}

	// Use this for initialization

	void Start () 
    {
        CurrentHealthValue = MaxHealthValue;
	}

    public float GetHealth()
    {
        return CurrentHealthValue;
    }
    public float GetMaxHealth()
    {
        return MaxHealthValue;
    }

    //Unit takes Damage
    public void Damage( float x)
    {
        if (CurrentHealthValue > 0)
        {
            CurrentHealthValue -= x;
            Debug.Log(gameObject.name + " has been DAMAGED for " + x + "!");
            if (CurrentHealthValue <= 0)
            {
                Debug.Log(gameObject.name + " + no Longer has any health!");
            }
        }
    }

    //Unit Heals Damage
    public void Heal(float x)
    {
        CurrentHealthValue += x;
        Debug.Log(gameObject.name + " has been HEALED for " + x + "!");
    }

    //Units Maximum health increases
    public void ChangeMax(float x)
    {
        MaxHealthValue += x;
        Debug.Log(gameObject.name + " 's Max health as INCREASED by " + x + "!");
    }


}
