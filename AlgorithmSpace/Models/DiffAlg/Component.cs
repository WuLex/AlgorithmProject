using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DiffAlg
{
    public class Component
    {
        public string name;
        public Props props;

        public Component(string name, Props props = null)
        {
            this.name = name;
            this.props = props;
        }

        public bool Equals(Component other)
        {
            if (other == null || name != other.name)
            {
                return false;
            }

            if (props == null && other.props == null)
            {
                return true;
            }

            return props.Equals(other.props);
        }
    }
}
