using Microsoft.VisualStudio.TestTools.UnitTesting;
using AISD2sem.SplayTree;

namespace SplayTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdding()
        {
            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);

            Assert.AreEqual<string>("100 200 50 40 30 20 ", splayTree.BreadthFirst());
        }

        [TestMethod]
        public void TestSearching()
        {
            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);

            splayTree.Search(20);

            Assert.AreEqual<string>("20 50 100 30 200 40 ", splayTree.BreadthFirst());
        }
        [TestMethod]
        public void TestRemoving()
        {
            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);
            splayTree.Add(51);
            splayTree.Add(52);

            splayTree.Remove(50);

            Assert.AreEqual<string>("100 200 51 52 40 30 20 ", splayTree.BreadthFirst());
        }

    }
}
