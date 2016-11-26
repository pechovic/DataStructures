using System;
using Xunit;

namespace DataStructures.Test
{
    public class AvlTreeNodeTest
    {
        
        [Fact]
        public void Add_RootNode_Ok()
        {
            var node = new AvlTreeNode<int>(1);
            node.Add(new AvlTreeNode<int>(2));

            Assert.Equal(node, node.GetRoot());
            Assert.Equal(1, node.GetRoot().Height);
        }

        [Fact]
        public void Insert_Balance_0()
        {
            var rootNode = Get12345Tree();
            Assert.Equal(TreeState.Balanced, rootNode.State);
        }

        [Fact]
        public void Insert_Height_Ok()
        {
            var rootNode = Get12345Tree();
            Assert.Equal(2, rootNode.Height);
        }
        
        [Fact]
        public void RightRotation_Ok()
        {
            // on the following tree the right rotation will be performed
            var node = new AvlTreeNode<int>(5);
            node.Add(new AvlTreeNode<int>(4));
            node.Add(new AvlTreeNode<int>(3));
            
            Assert.Equal(4, node.GetRoot().Value);
            Assert.Equal(3, node.GetRoot().LeftNode.Value);
            Assert.Equal(5, node.GetRoot().RightNode.Value);
            Assert.Equal(1, node.GetRoot().Height);
        }

        [Fact]
        public void LeftRotation_Ok()
        {
            // on the following tree the left rotation will be performed
            var node = new AvlTreeNode<int>(1);
            node.Add(new AvlTreeNode<int>(2));
            node.Add(new AvlTreeNode<int>(3));

            Assert.Equal(2, node.GetRoot().Value);
            Assert.Equal(1, node.GetRoot().LeftNode.Value);
            Assert.Equal(3, node.GetRoot().RightNode.Value);
            Assert.Equal(1, node.GetRoot().Height);
        }

        [Fact]
        public void Add_Balance_Height_Find_Ok()
        {
            var rootNode = GetBigTree();
            
            Assert.Equal(9, rootNode.Height);

            Type empty = typeof(AvlTreeNode<int>.EmptyLeaf);
            Assert.IsNotType(empty, rootNode.Find(9));
            Assert.IsNotType(empty, rootNode.Find(998));
            Assert.IsNotType(empty, rootNode.Find(345));
            Assert.IsNotType(empty, rootNode.Find(789));

            Assert.IsType(empty, rootNode.Find(10900998));
        }

        [Fact]
        public void RightLeftRotation_Ok()
        {
            var node = new AvlTreeNode<int>(3);
            node.Add(new AvlTreeNode<int>(1));
            node.Add(new AvlTreeNode<int>(2));

            Assert.Equal(2, node.GetRoot().Value);
            Assert.Equal(1, node.GetRoot().LeftNode.Value);
            Assert.Equal(3, node.GetRoot().RightNode.Value);
            Assert.Equal(1, node.GetRoot().Height);
        }

        [Fact]
        public void Remove_Ok()
        {
            var rootNode = GetBigTree();

            Assert.Equal(9, rootNode.Height);
            rootNode.Remove(rootNode.Find(9));
            rootNode.Remove(rootNode.Find(128));
            Assert.True(rootNode.Find(9).IsEmpty);
            Assert.True(rootNode.Find(128).IsEmpty);

            for (int i = 2; i < 1000; i++)
            {
                if (i != 9 && i != 128) 
                {
                    Assert.False(rootNode.Find(i).IsEmpty, "Failed to find node: " + i);
                }
            }
        }

        [Fact]
        public void FindTest()
        {
            var rootNode = GetBigTree();

            Type empty = typeof(AvlTreeNode<int>.EmptyLeaf);
            Assert.False(rootNode.Find(32).IsEmpty);
        }

        [Fact]
        public void MinTest()
        {
            var node = Get12345Tree();
            Assert.Equal(1, node.Min().Value);
        }

        [Fact]
        public void MinTest_Big()
        {
            var node = GetBigTree();
            Assert.Equal(1, node.Min().Value);
        }

        [Fact]
        public void MaxTest()
        {
            var node = Get12345Tree();
            Assert.Equal(5, node.Max().Value);
        }

        [Fact]
        public void MaxTest_Big()
        {
            var node = GetBigTree();
            Assert.Equal(999, node.Max().Value);
        }

        private AvlTreeNode<int> Get12345Tree()
        {
            var tree = new AvlTreeNode<int>(1);
            tree.Add(new AvlTreeNode<int>(2));
            tree.Add(new AvlTreeNode<int>(3));
            tree.Add(new AvlTreeNode<int>(4));
            tree.Add(new AvlTreeNode<int>(5));

            return tree.GetRoot();
        }

        private AvlTreeNode<int> GetBigTree()
        {
            var tree = new AvlTreeNode<int>(1);
            for (int i = 2; i < 1000; i++)
            {
                tree.Add(new AvlTreeNode<int>(i));
            }

            return tree.GetRoot();
        }
    }
}
