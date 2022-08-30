namespace logicalTest.Classes
{
    public class Network
    {
        public List<Node> node;
        private int nodesQuantity;

        //Method responsible for creating the nodes
        public Network(int quantity)
        {
            if (quantity > 0)
            {
                nodesQuantity = quantity;
                node = new List<Node>();
                for (int i = 1; i <= quantity; i++)
                {
                    node.Add(new Node(i));
                }
            }
            else
            {
                throw new Exception("Quantity must be positive and integer");
            }
        }

        //Method responsible for connecting the nodes
        public void connect(int firstNode, int secondNode)
        {
            if (firstNode > 0 && secondNode > 0)
            {
                if (firstNode <= nodesQuantity && secondNode <= nodesQuantity)
                {
                    node[firstNode - 1].setNewConnection(secondNode);
                    node[secondNode - 1].setNewConnection(firstNode);
                }
            }
            else
            {
                throw new Exception("Node must be positive and integer");
            }
        }

        //Method responsible for verifying the connections between the nodes
        public bool query(int firstNode, int secondNode)
        {
            if (!node[firstNode - 1].getConnections().Any())
            {
                Console.WriteLine(node[firstNode - 1].value + " has no connections");
                return false;
            }

            if (!node[secondNode - 1].getConnections().Any())
            {
                Console.WriteLine(node[secondNode - 1].value + " has no connections");
                return false;
            }

            List<int> nodeConnections = node[firstNode - 1].getConnections();

            foreach (int node in nodeConnections)
            {
                if (node == secondNode)
                {
                    return true;
                }
            }

            List<int> checkedNodesList = new List<int>();
            checkedNodesList.Add(firstNode);

            return IndirectConnection(firstNode, secondNode, checkedNodesList);
        }

        //Method responsible for checking indirect connections
        private bool IndirectConnection(int firstNode, int secondNode, List<int> checkedItems)
        {
            foreach (int connection in node[firstNode - 1].getConnections())
            {
                if (checkedItems.Where(s => s == connection).Any())
                {
                    continue;
                }
                else
                {
                    if (connection == secondNode)
                    {
                        return true;
                    }
                    else
                    {
                        checkedItems.Add(connection);
                        return IndirectConnection(connection, secondNode, checkedItems);
                    }
                }
            }

            return false;
        }
    }
}