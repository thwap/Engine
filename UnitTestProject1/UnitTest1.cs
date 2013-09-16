using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;
using System.Diagnostics;
namespace Engine
{
    [TestClass]
    public class UnitTest1
    {
        
        int a, b, c;
        Vector3 vecA,vecB;
        Stopwatch swA;
        [TestInitialize]
        public void SetUp()
        {
            swA = new Stopwatch();
            a = 10;
            b = 10;
            c = 0;
            vecA = new Vector3(a,b,c);
            a = 10;
            b = 0;
            vecB = new Vector3(a,b,c);
        }
        [TestMethod]
        public void TestMethod1()
        {

            float f = 45f * Mathf.Deg2Rad;
            float res = (float)Math.Cos(f);
            if (res == 100)
            {
                // Unused code
                res = 150;
            }
            vecA.Normalize();
            vecB.Normalize();
            swA.Start();
            float dot = Vector3.Dot(vecA, vecB);
            swA.Stop();
            Assert.AreEqual(dot,res);
            Console.WriteLine(swA.ElapsedMilliseconds);
        }
    }
}
