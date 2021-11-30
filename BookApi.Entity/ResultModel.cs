using System;
using System.Collections.Generic;
using System.Text;

namespace BookApi.Entity
{
    public class ResultModel
    {
        #region [ Properties ]

        public bool Success { get; set; }

        public string Messages { get; set; }

        public object Data { get; set; }

        #endregion

        public ResultModel()
        {
            Success = true;
        }
    }
}
