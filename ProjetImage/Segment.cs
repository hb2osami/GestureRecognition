///<summary>
///This class contains a lot of methods that can be used to treat a skeleton 
/// 
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage
{
    class Segment
    {
        /// <summary>
        /// Function to test if a joint is tracked 
        /// </summary>
        /// <param name="a"> The joint concerned</param>
        /// <returns>boolean </returns>
        public bool  isTracked( Joint a )
        {
            if (a.TrackingState == JointTrackingState.Tracked) return true;
            return false;
        }
        /// <summary>
        /// Function that return the number of hands tracked 
        /// </summary>
        /// <returns></returns>
        public int numberofHands()
        {
            return 1;
        }
        /// <summary>
        /// function to check if two jointss have the same coordinate x with a margin defined by the user
        /// </summary>
        /// <param name="a"> The First Joint</param>
        /// <param name="b">The Second Joint</param>
        /// <param name="margin"> the margin</param>
        /// <returns>a boolean </returns>
        public bool sameX(Joint a , Joint b , double  margin) {
            if (a.Position.X < b.Position.X +margin
                && b.Position.X  - margin < a.Position.X)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// function to check if two jointss have the same coordinate y with a margin defined by the user
        /// </summary>
        /// <param name="a"> The First Joint</param>
        /// <param name="b">The Second Joint</param>
        /// <param name="margin">margin </param>
        /// <returns>boolean </returns>
        public bool sameY(Joint a , Joint b , double  margin) {
            if (a.Position.Y < b.Position.Y + margin
                && b.Position.Y - margin < a.Position.Y)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// function to check if two jointss have the same coordinate z with a margin defined by the user
        /// </summary>
        /// <param name="a"> The First Joint</param>
        /// <param name="b">The Second Joint</param>
        /// <param name="margin">margin </param>
        /// <returns>boolean </returns>
        public bool sameZ(Joint a, Joint b, double  margin)
        {
            if (a.Position.Z < b.Position.Z + margin
                && a.Position.Z - margin < a.Position.Z)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// function to test if the hand is in the right up zone 
        /// </summary>
        /// <param name="skeleton">the skeleton concerned </param>
        /// <returns>boolean result </returns>
        public bool inRightUpZone(Skeleton skeleton) {
            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
            {
                if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// function to test if the hand is in the left up zone 
        /// </summary>
        /// <param name="skeleton">the skeleton concerned </param>
        /// <returns>boolean result </returns>
        public bool inLeftUpZone(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.ElbowLeft].Position.Y)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// function to test if a joint is rightUp of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool inRightUp(Joint a , Joint b)
        {   
            if (a.Position.Y > b.Position.Y)
            {

                if (a.Position.X > b.Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// function to test if a joint is right Down of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool inRightDown(Joint a, Joint b)
        {
            if (a.Position.Y < b.Position.Y)
            {

                if (a.Position.X > b.Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// fnction to test if a joint is left up of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool inLeftUp(Joint a, Joint b)
        {
            if (a.Position.Y > b.Position.Y)
            {

                if (a.Position.X < b.Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// fnction to test if a joint is left down of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool inLeftDown(Joint a, Joint b)
        {
            if (a.Position.Y < b.Position.Y)
            {

                if (a.Position.X < b.Position.X)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// fnction to test if a joint is Up of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool up(Joint a, Joint b)
        {
            return a.Position.Y > b.Position.Y;

        }
        /// <summary>
        /// fnction to test if a joint is Down of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool  down(Joint a, Joint b )
        {
            return a.Position.Y < b.Position.Y;
        }
        /// <summary>
        /// fnction to test if a joint is Right of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool right(Joint a, Joint b)
        {
            return a.Position.X > b.Position.X;
        }
        /// <summary>
        /// fnction to test if a joint is Left of other joint b 
        /// </summary>
        /// <param name="a">The first joint</param>
        /// <param name="b">the second joint </param>
        /// <returns>boolean result </returns>
        public bool left(Joint a, Joint b)
        {
            return a.Position.X < b.Position.X;
        }
        /// <summary>
        /// function to calculate the euclidian disance between two joints
        /// </summary>
        /// <param name="hx">1 st coordinate x</param>
        /// <param name="hy">1 st coordinate y</param>
        /// <param name="cx">2 nd coordinate x</param>
        /// <param name="cy">2 nd coordinate y</param>
        /// <returns></returns>
        public double euclidianDistance(float hx, float hy, float cx, float cy)
        {
            return Math.Sqrt((hx - cx) * (hx - cx) + (hy - cy) * (hy - cy));
        }
        /// <summary>
        /// function to test if the hand is in the right up zone followin direction z
        /// </summary>
        /// <param name="skeleton">the skeleton concerned </param>
        /// <returns>boolean result </returns>
        public bool inRightUpZoneZ(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandRight].Position.Z > skeleton.Joints[JointType.ElbowRight].Position.Z)
            {
                if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// function to test if the hand is in the left up zone 
        /// </summary>
        /// <param name="skeleton">the skeleton concerned </param>
        /// <returns>boolean result </returns>
        public bool inLeftUpZoneZ(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.Z > skeleton.Joints[JointType.ElbowLeft].Position.Z)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
