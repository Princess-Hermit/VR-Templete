﻿using UnityEngine;
using System.Collections;


namespace MalbersAnimations
{
    /// <summary>
    /// Simple Script to make damage to every Animal
    /// </summary>
    public class MakeDamage : MonoBehaviour
    {
        public float damageMultiplier = 1;

        void OnTriggerEnter(Collider other)
        {
            Animal myAnimal = transform.root.GetComponent<Animal>();

            Vector3 direction = -other.bounds.center + GetComponent<Collider>().bounds.center;

            DamageValues DV = new DamageValues(direction, damageMultiplier * (myAnimal ? myAnimal.attackStrength : 1));

            if (other.isTrigger) return; // just collapse when is a collider what we are hitting

            if (myAnimal)
            {
                if (myAnimal.IsAttacking)
                {
                    myAnimal.getDamaged(DV);
                    myAnimal.IsAttacking = false;
                }
            }
            else
            {
                other.transform.root.SendMessage("getDamaged", DV, SendMessageOptions.DontRequireReceiver);
            }
        }
    }


}
