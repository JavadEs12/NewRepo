namespace ShortestPath
{
    public class Heap
    {
        public Node root;
        public Node pointer;
        public int count;
        public Heap(Dictionary<string, Node> nodes)
        {
            count = 0;
            foreach (KeyValuePair<string, Node> node in nodes)
            {
                Add(node.Value);
            }
        }

        public Heap()
        {

        }
        public void Add(Node node)
        {
            if (root == null)
            {
                root = new Node(node.ID, node.Cost);
                count++;
            }
            else
            {
                pointer = root;
                string bitcount = Convert.ToString(count + 1, 2);  //converts integer value to its binary form 
                for (int i = 1; i < bitcount.Length; i++)   //start from second element of binary to exclude the parent
                {
                    if (bitcount[i] == '0')
                    {
                        if (pointer.Left == null)
                        {
                            pointer.Left = new Node(pointer); //Node(Node P) is a costructor which creates an empty Node with its Parent
                        }
                        pointer = pointer.Left;
                    }
                    else
                    {
                        if (pointer.Right == null)
                        {
                            pointer.Right = new Node(pointer);
                        }
                        pointer = pointer.Right;
                    }
                }
                pointer.Cost = node.Cost;
                pointer.ID = node.ID;

                while (true)
                {
                    if (pointer == root) { break; }
                    if (pointer.Cost < pointer.Parent.Cost)
                    { //Switch data
                        double tempCost = pointer.Cost;
                        pointer.Cost = pointer.Parent.Cost;
                        pointer.Parent.Cost = tempCost;

                        string tempID = pointer.ID;
                        pointer.ID = pointer.Parent.ID;
                        pointer.Parent.ID = tempID;

                        pointer = pointer.Parent;
                    }
                    else
                    {
                        break;
                    }
                }
                count++;
            }
        }
        public Node Remove()
        {
            Node output = root;
            pointer = root;
            string bitcount = Convert.ToString(count, 2);
            for (int i = 1; i < bitcount.Length; i++)
            {
                if (bitcount[i] == '0')
                {
                    pointer = pointer.Left;
                }
                else
                {
                    pointer = pointer.Right;
                }
            }
            root.Cost = pointer.Cost;  // set root equal to last filled space in heap
            root.ID = pointer.ID;
            try
            {
                //delete last filled space in heap 
                if (pointer.Parent.Left == pointer)
                {
                    pointer.Parent.Left = null;
                }
                else
                {
                    pointer.Parent.Right = null;
                }
                count--;
                Heapify();  // perculate down new root
            }
            catch
            {
                root = null;
            }
            return output;
        }


        private void Heapify()
        {
            Node compare;
            pointer = root;

            while (true)
            {
                if (pointer.Left == null)
                {
                    break;
                }
                if (pointer.Right == null)
                {
                    compare = pointer.Left;
                }
                else
                {
                    if (pointer.Left.Cost <= pointer.Right.Cost)
                    {
                        compare = pointer.Left;
                    }
                    else
                    {
                        compare = pointer.Right;
                    }
                }
                if (pointer.Cost > compare.Cost)
                {
                    double tempCost = pointer.Cost;
                    pointer.Cost = compare.Cost;
                    compare.Cost = tempCost;

                    string tempID = pointer.ID;
                    pointer.ID = compare.ID;
                    compare.ID = tempID;
                    pointer = compare;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
