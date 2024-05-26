using lab_5.State;

namespace lab_5.LightHTML;

abstract class LightNode
{
    public virtual IState State { get; set; }
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
}