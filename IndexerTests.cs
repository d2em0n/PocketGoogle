using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    [TestFixture]
    public class Tests
    {
        [Test]       
        public void SingleTest()
        {
            var test = new Indexer();
            test.Add(0, "A B C");
            test.Add(1, "B C");
            test.Add(2, "A C A C");
            test.Add(3, "F, f ff");

            Assert.AreEqual(new List<int>() { 0, 2 } , test.GetIds("A"));
        }
    }
}
