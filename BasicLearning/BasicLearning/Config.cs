using System.IO;
using LitJson;

namespace BasicLearning
{
    public class Config
    {
        private string projectPathStr;
        
        private JsonData gofConfigData;
        
        public Config()
        {
            InitProjectPath();
            LoadGlobalConfig();
        }
        
        private void InitProjectPath()
        {
            string pathStr = Directory.GetCurrentDirectory(); //取得或设置当前工作目录的完整限定路径
            DirectoryInfo pathInfo = new DirectoryInfo(pathStr);
            projectPathStr = pathInfo.Parent.Parent.FullName;
        }

        private void LoadGlobalConfig()
        {
            string gofConfigPathStr = projectPathStr + "\\Res\\GoF\\GoFConfig.json";
            gofConfigData = JsonMapper.ToObject(File.ReadAllText(gofConfigPathStr));
        }

        #region GoF
        
        public string GetSimpleFactory()
        {
            return gofConfigData["SimpleFactory"].ToString();
        }
        
        public string GetFunFactory()
        {
            return gofConfigData["FunFactory"].ToString();
        }
        
        public string GetAbstructFactory()
        {
            return gofConfigData["AbstructFactory"].ToString();
        }
        
        public string GetBuilder()
        {
            return gofConfigData["Builder"].ToString();
        }
        
        public string GetAdapter()
        {
            return gofConfigData["Adapter"].ToString();
        }
        
        public string GetBridgeConcreteImplementor()
        {
            return gofConfigData["BridgeConcreteImplementor"].ToString();
        }

        public string GetBridgeRefinedAbstraction()
        {
            return gofConfigData["BridgeRefinedAbstraction"].ToString();
        }
        
        #endregion
    }
}