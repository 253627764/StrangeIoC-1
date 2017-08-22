using System.Diagnostics;
using strange.extensions.context.impl;

public class Demo1ContextView : ContextView 
{
    void Awake()
    {
        this.context=new Demo1Context(this);//创建context
    }

}
