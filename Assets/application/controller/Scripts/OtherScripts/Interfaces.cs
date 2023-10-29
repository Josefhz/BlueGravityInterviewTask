using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{
    public interface IStat
    {
        public int TakeDamage(int pDamage);
    }
}
