using System.IO;
using LitJson;

namespace BasicLearning
{
    public class Config
    {
        private string projectPathStr;
        
        private JsonData globalConfigData;
        
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
            string globalConfigPathStr = projectPathStr + "\\Res\\GlobalConfig.json";
            globalConfigData = JsonMapper.ToObject(File.ReadAllText(globalConfigPathStr));
        }
        
        public string GetSimpleFactory()
        {
            return globalConfigData["SimpleFactory"].ToString();
        }
        
        public string GetFunFactory()
        {
            return globalConfigData["FunFactory"].ToString();
        }
        
        public string GetAbstructFactory()
        {
            return globalConfigData["AbstructFactory"].ToString();
        }
        
        public string GetBuilder()
        {
            return globalConfigData["Builder"].ToString();
        }
        
        public string GetAdapter()
        {
            return globalConfigData["Adapter"].ToString();
        }
    }
}