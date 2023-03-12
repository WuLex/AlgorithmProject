using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DiffAlg
{
    public class Props
    {
        public Dictionary<string, string> attributes = new Dictionary<string, string>();

        public Props(Dictionary<string, string> attributes = null)
        {
            if (attributes != null)
            {
                this.attributes = attributes;
            }
        }

        public bool Equals(Props other)
        {
            if (other == null || attributes.Count != other.attributes.Count)
            {
                return false;
            }

            foreach (KeyValuePair<string, string> pair in attributes)
            {
                string value;
                if (other.attributes.TryGetValue(pair.Key, out value))
                {
                    if (value != pair.Value)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
