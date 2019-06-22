///<summary>
///The abstract class Gesturr , if someone wants to implement a new gesture he needs to inherit the new gesture class from this Class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace ProjetImage

{
    abstract class Gesture
    {
        // Number Of Frames 60 correponds to 2 s
        protected  int nbFrames = 60;
        protected  Segment segment;
        protected  Skeleton[] skeletons;

        public abstract void update(Skeleton skeleton);
        /// <summary>
        /// its an abstract method for each gesture this method treat each skeleton received
        /// </summary>
        /// <param name="skeleton">The skeleton treated</param>
        /// <returns></returns>
        /// 
        ///<summary>
        /// function that defines the start position
        /// if the skeleton represnts a start position then we can begin saving records
        /// </summary>
        /// <param name="skeleton">The skeleton treated</param>
        /// <returns></returns>
        ///</summary>
        public abstract bool startPosition(Skeleton skeleton);
        /// <summary>
        /// the event raised if a gesture is recognied
        /// </summary>
        public abstract  event EventHandler GestureRecognized;
        /// <summary>
        /// function to reset the parametrs it can be overried if other parametrs are difine
        /// </summary>
        public virtual  void reset()
        {
            skeletons = new Skeleton[nbFrames];
        }
        /// <summary>
        /// The constructor class
        /// </summary>
        public Gesture() {
            segment = new Segment();
            skeletons = new Skeleton[nbFrames];
        }
    }
}
