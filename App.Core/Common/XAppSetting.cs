//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AIMCPHub.Common
//{
//    public class XAppSetting
//    {
//        private static XAppSetting _instance;
//        private static readonly object ObjLocked = new object();
//        public IConfiguration Configuration { get; private set; }

//        protected XAppSetting()
//        {
//        }

//        public static XAppSetting Instance
//        {
//            get
//            {
//                if (null != _instance) return _instance;
//                lock (ObjLocked)
//                {
//                    _instance ??= new XAppSetting();
//                }

//                return _instance;
//            }
//        }

//        public void SetConfiguration(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public static T Get<T>(string key = null)
//        {
//            if (string.IsNullOrWhiteSpace(key)) return Instance.Configuration.Get<T>();

//            var section = Instance.Configuration.GetSection(key);
//            return section.Get<T>();
//        }

//        public static T Get<T>(string key, T defaultValue)
//        {
//            if (Instance.Configuration.GetSection(key) == null)
//                return defaultValue;

//            if (string.IsNullOrWhiteSpace(key))
//                return Instance.Configuration.Get<T>();
//            var value = Instance.Configuration.GetSection(key).Get<T>();
//            return value == null || EqualityComparer<T>.Default.Equals(value, default) ? defaultValue : value;
//        }
//    }
//}
