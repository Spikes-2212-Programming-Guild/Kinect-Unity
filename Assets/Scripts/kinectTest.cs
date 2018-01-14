using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Kinect;
using System.Linq;

public class kinectTest : MonoBehaviour
{
    KinectSensor kinect = null;
    SkeletonPoint rightHand;
    SkeletonPoint leftHand;
    SkeletonPoint rightKnee;
    SkeletonPoint leftKnee;
    object locker = new object();

    // Use this for initialization
    void StartKinectST()
    {
        print("Start Kinect");
        kinect = KinectSensor.KinectSensors.FirstOrDefault(s => s.Status == KinectStatus.Connected); // Get first Kinect Sensor
        //kinect = KinectSensor.KinectSensors.FirstOrDefault();
        kinect.SkeletonStream.Enable(); // Enable skeletal tracking
        kinect.SkeletonFrameReady += SkeletonDataReady;

        kinect.Start(); // Start Kinect sensor
    }

    private void SkeletonDataReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (var frame = e.OpenSkeletonFrame())
        {
            Skeleton[] sk = new Skeleton[frame.SkeletonArrayLength];
            frame.CopySkeletonDataTo(sk);

            Skeleton skel = sk.FirstOrDefault(x => x.TrackingState == SkeletonTrackingState.Tracked);
            if (skel == null)
            {
                return;
            }

            var RHand = skel.Joints[JointType.HandRight];
            var LHand = skel.Joints[JointType.HandLeft];
            var RKnee = skel.Joints[JointType.KneeRight];
            var LKnee = skel.Joints[JointType.KneeLeft];
            lock (locker)
            {
                rightHand = RHand.Position;
                leftHand = LHand.Position;
                rightKnee = RKnee.Position;
                leftKnee = LKnee.Position;
            }
        }

    }

    void Start()
    {
        StartKinectST();
    }

    // Update is called once per frame
    void Update()
    {
        float xRH, yRH, zRH, xLH, yLH, zLH, xRK, yRK, zRK, xLK, yLK, zLK;
        lock (locker)
        {
            xRH = rightHand.X;
            yRH = rightHand.Y;
            zRH = rightHand.Z;

            xLH = leftHand.X;
            yLH = leftHand.Y;
            zLH = leftHand.Z;

            xRK = rightKnee.X;
            yRK = rightKnee.Y;
            zRK = rightKnee.Z;

            xLK = leftKnee.X;
            yLK = leftKnee.Y;
            zLK = leftKnee.Z;
        }

        Debug.Log("Right Hand" + xRH + "," + yRH + "," + zRH);
        Debug.Log("Left Hand" + xLH + "," + yLH + "," + zLH);
        Debug.Log("Right Knee" + xRK + "," + yRK + "," + zRK);
        Debug.Log("Left Knee" + xLK + "," + yLK + "," + zLK);

    }
}
