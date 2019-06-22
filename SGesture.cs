///<summary>
///The abstract class I used to define all my Gestures , the S refired to Sami
///If a potential developper agrees with my method he can inherit directly from this class and define the abstract methods I used 
///else he can inherit from Gesture class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
     abstract class SGesture : Gesture
    {
        // The Index of the beginig of the gesture
        protected int indexDebut = 0;
        // The Index of the end of the gesture 
        protected int indexFin = 0;
        // The current Index 
        protected int indexCourant = 0;

        public override event EventHandler GestureRecognized;
        /// <summary>
        /// Function to check if the skeleton can define the begining of the gesture
        /// 
        /// </summary>
        /// <param name="skeleton">The Skeleton treated</param>
        /// <returns>boolean result </returns>
        public abstract bool start(Skeleton skeleton);
        /// <summary>
        /// Function to check if the skeleton can define the end of the gesture
        /// 
        /// </summary>
        /// <param name="skeleton">The Skeleton treated</param>
        /// <returns>boolean result </returns>
        public abstract bool end(Skeleton skeleton);
        /// <summary>
        /// function to check if the skeletons saved verify the condition of the gesture 
        /// </summary>
        /// <returns></returns>
        public abstract bool check();
        /// <summary>
        /// function to save each skeleton , start and end position
        /// </summary>
        /// <param name="skeleton"></param>
        private void save(Skeleton skeleton) {
            Console.WriteLine(indexCourant);
            float rightHX = skeleton.Joints[JointType.WristRight].Position.X;
            float rightEX = skeleton.Joints[JointType.ElbowRight].Position.X;
            float rightHY = skeleton.Joints[JointType.WristRight].Position.Y;
            float rightEY = skeleton.Joints[JointType.ElbowRight].Position.Y;

            Console.WriteLine("X Hand : " + rightHX + "Y Elbow" + rightEX);
            Console.WriteLine("Y Hand : " + rightHY + "Y Elbow :" + rightEY);

            if (start(skeleton))
            {
                indexDebut = indexCourant;
            }
            if (end(skeleton))
            {
                indexFin = indexCourant;
            }
            skeletons[indexCourant] = skeleton;
            indexCourant++;
        }

        public override void update(Skeleton skeleton)
        {
            if (indexCourant < nbFrames)
            {
                save(skeleton);   
            }
            if (indexCourant == nbFrames)
            {
                if (indexFin == 0) indexFin = 60;
                Console.WriteLine("details :\n");
                Console.WriteLine("Index Debut :" + indexDebut);
                Console.WriteLine("Index Fin :" + indexFin);
                Console.WriteLine("Nombre archives :" + skeletons.Length);
                indexCourant = nbFrames + 1;
            }
            else if (indexCourant > nbFrames)
            {
                if (check())
                {
                    GestureRecognized(this, new EventArgs());
                }
            }
        }
        public  override void reset()
        {
            indexDebut = 0;
            indexFin = 0;
            indexCourant = 0;
            skeletons = new Skeleton[nbFrames];
        }
    }

}
