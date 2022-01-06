namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲开发一个视频播放软件，为了给用户使用提供方便，该播放软件提供多种界面显示模式，如完整模式、精简模式、记忆模式、网络模式等。
        在不同的显示模式下主界面的组成元素有所差异，如在完整模式下将显示菜单、播放列表、主窗口、控制条等，
        在精简模式下只显示主窗口和控制条，而在记忆模式下将显示主窗口、控制条、收藏列表等。尝试使用建造者模式设计该软件。
     */
    public abstract class VideoInterfaceBuilder
    {
        protected VideoInterface videoInterface = new VideoInterface();
        
        protected abstract void BuildMenu();
        protected abstract void BuildPlayList();
        protected abstract void BuildMainWin();
        protected abstract void BuildProgressBar();
        protected abstract void BuildCollectList();

        protected virtual bool IsMenu()
        {
            return true;
        }

        protected virtual bool IsPlayList()
        {
            return true;
        }

        protected virtual bool IsMainWin()
        {
            return true;
        }

        protected virtual bool IsProgressBar()
        {
            return true;
        }

        protected virtual bool IsCollectList()
        {
            return true;
        }
        
        public VideoInterface Builder()
        {
            if(IsMenu())
                BuildMenu();
            
            if(IsPlayList())
                BuildPlayList();
            
            if(IsMainWin())
                BuildMainWin();
            
            if(IsProgressBar())
                BuildProgressBar();
            
            if(IsCollectList())
                BuildCollectList();
            
            return videoInterface;
        }
    }

    public class FullVideoInterfaceBuilder:VideoInterfaceBuilder
    {
        protected override void BuildMenu()
        {
            videoInterface.Menu = "完整模式菜单";
        }

        protected override void BuildPlayList()
        {
            videoInterface.PlayList = "完整模式播放列表";
        }

        protected override void BuildMainWin()
        {
            videoInterface.MainWin = "完整模式主窗口";
        }

        protected override void BuildProgressBar()
        {
            videoInterface.ProgressBar = "完整模式控制条";
        }

        protected override void BuildCollectList()
        {
            videoInterface.CollectList = "完整模式收藏列表";
        }

        protected override bool IsCollectList()
        {
            return false;
        }
    }

    public class SimplifyVideoInterfaceBuilder:VideoInterfaceBuilder
    {
        protected override void BuildMenu()
        {
            videoInterface.Menu = "精简模式菜单";
        }

        protected override void BuildPlayList()
        {
            videoInterface.PlayList = "精简模式播放列表";
        }

        protected override void BuildMainWin()
        {
            videoInterface.MainWin = "精简模式主窗口";
        }

        protected override void BuildProgressBar()
        {
            videoInterface.ProgressBar = "精简模式控制条";
        }

        protected override void BuildCollectList()
        {
            videoInterface.CollectList = "精简模式收藏列表";
        }

        protected override bool IsMenu()
        {
            return false;
        }

        protected override bool IsPlayList()
        {
            return false;
        }

        protected override bool IsCollectList()
        {
            return false;
        }
    }

    public class MemoryVideoInterfaceBuilder:VideoInterfaceBuilder
    {
        protected override void BuildMenu()
        {
            videoInterface.Menu = "记忆模式菜单";
        }

        protected override void BuildPlayList()
        {
            videoInterface.PlayList = "记忆模式播放列表";
        }

        protected override void BuildMainWin()
        {
            videoInterface.MainWin = "记忆模式主窗口";
        }

        protected override void BuildProgressBar()
        {
            videoInterface.ProgressBar = "记忆模式控制条";
        }

        protected override void BuildCollectList()
        {
            videoInterface.CollectList = "记忆模式收藏列表";
        }

        protected override bool IsMenu()
        {
            return false;
        }

        protected override bool IsPlayList()
        {
            return false;
        }
    }

    public class VideoInterface
    {
        public string Menu;
        public string PlayList;
        public string MainWin;
        public string ProgressBar;
        public string CollectList;

        public override string ToString()
        {
            string title = "视频界面包含\r\n";
            string info = "";
            if (!string.IsNullOrEmpty(Menu))
                info += Menu;
            if (!string.IsNullOrEmpty(PlayList))
                info += string.IsNullOrEmpty(info) ? PlayList : "、" + PlayList;
            if (!string.IsNullOrEmpty(MainWin))
                info += string.IsNullOrEmpty(info) ? MainWin : "、" + MainWin;
            if (!string.IsNullOrEmpty(ProgressBar))
                info += string.IsNullOrEmpty(info) ? ProgressBar : "、" + ProgressBar;
            if (!string.IsNullOrEmpty(CollectList))
                info += string.IsNullOrEmpty(info) ? CollectList : "、" + CollectList;
            return title + info;
        }
    }
}