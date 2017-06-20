using UnityEngine;

namespace MalbersAnimations
{
    //Basic inventory veeeery Basic
    public class MInventory : MonoBehaviour
    {
        public InputRow Slot1 = new InputRow(KeyCode.Alpha4);   //Input for Slot1
        public InputRow Slot2 = new InputRow(KeyCode.Alpha5);   //Input for Slot2
        public InputRow Slot3 = new InputRow(KeyCode.Alpha6);   //Input for Slot3

        public GameObject[] Slots;

        protected int ActiveHolder;         //ID of the active Holder
        protected GameObject activeWeapon;  //Current Active Weapon

        void Start()
        {
            EquipItemCallBack(1);
        }

        void Update()
        {
            if (Slot1.GetInput) EquipItemCallBack(1);
            if (Slot2.GetInput) EquipItemCallBack(2);
            if (Slot3.GetInput) EquipItemCallBack(3);
        }

        public virtual void EquipItemCallBack(int Slot)
        {
            GameObject ItemToSend = Slots[Slot - 1];
            if (ItemToSend != null)
            {
                SendMessage("GetWeaponByInventory", ItemToSend, SendMessageOptions.DontRequireReceiver); //Send Active Weapon to the Rider Combat
            }
        }
    }
}