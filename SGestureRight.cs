///<summary>
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
    class SGestureRight : SGesture
    {
        public override bool check()
        {
            if (indexDebut != 0 && indexFin != 0)
            {
                for (int i = indexDebut + 1; i < indexFin; i++)
                {
                    if (!segment.inRightUpZone(skeletons[i]))
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

        public override bool end(Skeleton skeleton)
        {
            if (segment.sameY(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03))
            {
                return true;
            }
            return false;
        }

        public override bool start(Skeleton skeleton)
        {
            if(segment.sameX(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03))
            {
                return true;
            }
            return false;

        }

        public override bool startPosition(Skeleton skeleton)
        {
            return segment.inRightUp(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight]);
        }
    }
}
