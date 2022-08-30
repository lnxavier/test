using System;

namespace logicalTest.Classes
{
    public class Node
    {
        public int value { get; set; }
        private List<int> connections { get; set; }

        public Node(int initializer)
        {
            value = initializer;
            connections = new List<int>();
        }

        public void setNewConnection(int nodeValue)
        {
            connections.Add(nodeValue);
        }

        public List<int> getConnections()
        {
            return connections;
        }
    }
}
