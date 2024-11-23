using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.MiniKpay.Domain
{
    public class Result<T>
    {
        public bool IsSuccess {  get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public EnumRespType Type { get; set; }
        public T Data { get; set; }

    }
}
