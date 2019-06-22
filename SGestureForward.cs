using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
    class SGestureForward : SGesture
    {
        public override bool check()
        {
            if (indexDebut != 0 && indexFin != 0)
            {
                for (int i = indexDebut; i < indexFin; i++)
                {
                    if (!segment.inRightUpZoneZ(skeletons[i]))  
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
            if (segment.sameY(skeleton.Joints[JointType.WristLeft], skeleton.Joints[JointType.ElbowLeft], 0.03) && segment.sameY(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03))
            {
                return true;
            }
            return false;
        }

        public override bool start(Skeleton skeleton)
        {
            if (segment.sameZ(skeleton.Joints[JointType.WristLeft], skeleton.Joints[JointType.ElbowLeft], 0.03) && segment.sameY(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03) && segment.sameZ(skeleton.Joints[JointType.WristLeft], skeleton.Joints[JointType.ElbowLeft], 0.03) && segment.sameY(skeleton.Joints[JointType.WristRight], skeleton.Joints[JointType.ElbowRight], 0.03))
            {
                return true;
            }
            return false;
        }

        public override bool startPosition(Skeleton skeleton)
        {
            if (segment.inRightUpZoneZ(skeleton))
            {
                return true;
            }
            return false;
        }
    }
}
