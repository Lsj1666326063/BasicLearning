using System;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司欲开发一套图形界面类库。该类库需要包含若干预定义的窗格(Pane)对象，
        例如TextPane、ListPane、GraphicPane等，窗格之间不允许直接引用。
        基于该类库的应用由一个包含一组窗格的窗口(Window)组成，窗口需要协调窗格之间的行为。
        试采用中介者模式设计该系统。
        
        这个不太行...
     */

    public abstract class Pane
    {
        public AbMediator mediator;

        public Pane(AbMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Update();
    }

    public class TextPane : Pane
    {
        public TextPane(AbMediator mediator) : base(mediator)
        {
        }

        public override void Update()
        {
            Console.WriteLine($"更新文本");
        }
    }

    public class ListPane : Pane
    {
        public ListPane(AbMediator mediator) : base(mediator)
        {
        }

        public override void Update()
        {
            Console.WriteLine($"更新列表");
        }

        public void Select()
        {
            Console.WriteLine($"选中Item");
            mediator.UpdatePane(this);
        }
    }

    public class GraphicPane : Pane
    {
        public GraphicPane(AbMediator mediator) : base(mediator)
        {
        }

        public override void Update()
        {
            Console.WriteLine($"更新图表");
        }
    }
    
    
    public abstract class AbMediator
    {
        public TextPane Text;
        public ListPane List;
        public GraphicPane Graphic;
        
        public abstract void UpdatePane(Pane pane);
    }

    public class MediatorWindow : AbMediator
    {
        public override void UpdatePane(Pane pane)
        {
            if (pane == List)
            {
                Text.Update();
                Graphic.Update();
            }
        }
    }
}