using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
    class GestureRight : Gesture
    {
         protected  int  indexDebut = 0;
         protected int indexFin = 0;
         protected int   indexCourant = 0;

        public override event EventHandler GestureRecognized;
        public override void update(Skeleton skeleton)
        {   
            if (indexCourant < nbFrames) 
            {
                Console.WriteLine(indexCourant);
                float rightHX = skeleton.Joints[JointType.WristRight].Position.X;
                float rightEX = skeleton.Joints[JointType.ElbowRight].Position.X;
                float rightHY = skeleton.Joints[JointType.WristRight].Position.Y;
                float rightEY = skeleton.Joints[JointType.ElbowRight].Position.Y;
                Console.WriteLine("X Hand : " + rightHX + "Y Elbow" + rightEX);
                Console.WriteLine("Y Hand : " + rightHY + "Y Elbow :" + rightEY);

                if (segment.sameX(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03))
                {
                    Console.WriteLine(segment.sameX(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03));
                    indexDebut = indexCourant;
                }
                if (segment.sameY(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight] ,0.03))
                {
                    indexFin = indexCourant;
                }
                skeletons[indexCourant] = skeleton;
                indexCourant++;
            }
            if (indexCourant == nbFrames)
            {
                if (indexFin == 0) indexFin = 60;
                Console.WriteLine("details :\n");
                Console.WriteLine("Index Debut :"+indexDebut);
                Console.WriteLine("Index Fin :" +indexFin);
                Console.WriteLine("Nombre archives :" + skeletons.Length);
                indexCourant = nbFrames+1;
            }
            else if(indexCourant > nbFrames)
            {
                if (check())
                {
                    Console.WriteLine("PipPipPip");
                    GestureRecognized(this, new EventArgs());
                    reset();
                }
                
            }
        }
        private bool check() {
            if( indexDebut !=0 && indexFin !=0)
            {
                for ( int i = indexDebut+1; i<indexFin; i++)
                {
                    if(!segment.inRightUpZone(skeletons[i]))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void reset()
        {
            indexDebut = 0;
            indexFin = 0;
            indexCourant = 0;
            skeletons = new Skeleton[nbFrames];
        }

        public override bool startPosition(Skeleton skeleton)
        {
            return segment.inRightUp(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight]);
        }
    }
}
