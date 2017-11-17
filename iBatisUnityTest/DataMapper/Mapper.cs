using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;

namespace iBatisUnityTest.DataMapper
{
    public class Mapper : IMapper
    {
        private static volatile ISqlMapper _mapper = null;
        public ISqlMapper Instance
        {
            get
            {
                // 如果_mapper为空，则实例化
                if (_mapper == null)
                {
                    lock (typeof(SqlMapper))
                    {
                        if (_mapper == null) // double-check
                        {
                            InitMapper("Setting/ORM/SqlMap.config");
                        }
                    }
                }
                return _mapper;
            }
        }

        public void InitMapper(string sqlMapperPath)
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch(sqlMapperPath, handler);
            //解决当非Web请求线程调用时会出现的错误
            _mapper.SessionStore = new IBatisNet.DataMapper.SessionStore.HybridWebThreadSessionStore(_mapper.Id);
        }

        protected void Configure(object obj)
        {
            _mapper = null;
        }
    }
}