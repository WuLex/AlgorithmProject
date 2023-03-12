using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DiffAlg
{
    public class Children
    {
        public List<VNode> nodes = new List<VNode>();

        public Children(List<VNode> nodes = null)
        {
            if (nodes != null)
            {
                this.nodes = nodes;
            }
        }

        public bool Equals(Children other)
        {
            if (other == null || nodes.Count != other.nodes.Count)
            {
                return false;
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].Equals(other.nodes[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
