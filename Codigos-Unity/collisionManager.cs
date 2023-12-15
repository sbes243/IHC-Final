using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using UnityEngine;
using System.IO;

namespace Collisions
{
    public class collisionManager : MonoBehaviour
    {
        public bool obj1 = false;
        public bool obj2 = false;
        public bool obj3 = false;
        public bool obj4 = false;
        public bool cuve=false;
        string fp = "C:/Emotiv/Version3/Assets/Scripts/direction.txt";
        string right = "right";
        string left = "left";

        void Start()
        {
            if (File.Exists(fp))
            {
                Debug.Log(fp + " ya existe");
            }
            var sr = File.CreateText(fp);
        }

        // Update is called once per frame
        void Update()
        {

            if (obj1 == true && obj3 == true)
            {
                File.WriteAllText(fp, right);
                Debug.Log("detecto RIGHT");
            }

            if (obj2 == true && obj4 == true)
            {
                File.WriteAllText(fp,left);
                Debug.Log("detecto LEFT");
            }
           
        }
        public void SetAngle(float angle)
        {
            // Implement the logic to use the angle here
            // For example, you can print it to the console
            angle = angle / 90;
            string striangle = angle.ToString("0.00");
            char[] chars = striangle.ToCharArray();
            for (int i=0;i<striangle.Length;i++)
            {
                if (chars[i] == ',')
                {
                    chars[i] = '.';
                }
            }
            striangle= new string(chars);
            if (angle != 0)
            {
                File.WriteAllText(fp, striangle);
            }
            // Or perform other actions based on the angle
            if (angle > 0)
            {
                // Angle is positive, indicating right movement
            }
            else if (angle < 0)
            {
                // Angle is negative, indicating left movement
            }
            else
            {
                // Angle is 0, indicating no lateral movement
            }
        }
    }
}
