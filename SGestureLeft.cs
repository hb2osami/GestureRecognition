using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
    class SGestureLeft : SGesture
    {
        public override bool check()
        {
            if (indexDebut != 0 && indexFin != 0)
            {
                for (int i = indexDebut; i < indexFin; i++)
                {
                    if (!segment.inLeftUpZone(skeletons[i]))
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
            if (segment.sameY(skeleton.Joints[JointType.WristLeft], skeleton.Joints[JointType.ElbowLeft], 0.08))
            {
                return true;
            }
            return false;
        }

        public override bool start(Skeleton skeleton)
        {
            if (segment.sameX(skeleton.Joints[JointType.WristLeft], skeleton.Joints[JointType.ElbowLeft], 0.03))
            {
                return true;
            }
            return false;
        }

        public override bool startPosition(Skeleton skeleton)
        {
            if (segment.isTracked(skeleton.Joints[JointType.HandRight]) && segment.isTracked(skeleton.Joints[JointType.HandLeft]))
            {

            }
            return false;

        }
    }
}
