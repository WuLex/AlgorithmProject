using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DiffAlg
{
    public class VNode
    {
        public VNodeType type;
        public string tag;
        public string text;
        public Props props;
        public Component component;
        public Children children;

        public VNode(VNodeType type, string tag = null, string text = null, Props props = null, Component component = null, Children children = null)
        {
            this.type = type;
            this.tag = tag;
            this.text = text;
            this.props = props;
            this.component = component;
            this.children = children;
        }
    }
}
