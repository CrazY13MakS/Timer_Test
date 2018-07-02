using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimerUnitTest
{
    [TestClass]
    public class UnitTestTimer
    {
        static int count;
        [TestMethod]
        public void TestTimer()
        {
            int interval = 2000;
            int expect = 10;

            Timer_Test.Model.TimerSimple timer = new Timer_Test.Model.TimerSimple(interval);
            timer.Seconds = 20;
            timer.TimerElapsed += Timer_TimerElapsed;
            count = 0;
            timer.Start();
            Task.Delay(21000).Wait();
            Assert.AreEqual(expect, count);
        }

        private void Timer_TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            count++;
        }
    }
}
