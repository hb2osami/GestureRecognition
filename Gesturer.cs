using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
namespace ProjetImage
{
    class Gesturer
    {
        private Dictionary<String, Gesture> gestures;
        private bool isRec = false ;
        private Gesture currentGest = null;
        public event EventHandler GestureFound;

        public Gesturer()
        {
            gestures = new Dictionary<String ,Gesture>();
        }

        public  void addGesture(String nom , Gesture  gesture )
        {
            gesture.GestureRecognized += Gesture_GestureRecognized;
            gestures.Add(nom, gesture);
           
        }

        private void Gesture_GestureRecognized(object sender, EventArgs e)
        {
                Console.WriteLine("done done");
                ((SGesture)sender).reset();
                GestureFound(sender, new EventArgs());
                isRec = true;
                Console.WriteLine(isRec);
        }
        public  void  deleteGesture(String nom)
        {
            gestures.Remove(nom);
        }
        public void update(Skeleton skeleton)
        {
          //  Console.WriteLine(isRec);
            if (currentGest == null)
            {
                foreach (KeyValuePair<string, Gesture> gest in gestures)
                {
                    Console.WriteLine("Key "+gest.Key);
                    if (gest.Value.startPosition(skeleton))
                    {
                        currentGest = gest.Value;
                        Console.WriteLine("Gesture Found");
                    }
                }
            }
            else
            {
                if (isRec)
                {
                    reset();
                }
                else
                {
                    currentGest.update(skeleton);
                }
            }

        }
        private void reset()
        {
            currentGest = null;
            isRec = false;
        }
        public void restGestures()
        {
            foreach (KeyValuePair<string, Gesture> gest in gestures)
            {
                ((GestureRight)gest.Value).reset();
            }

        }
    }
}
