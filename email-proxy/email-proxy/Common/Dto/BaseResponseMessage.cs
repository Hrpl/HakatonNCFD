﻿namespace email_proxy.Common.Dto
{
    public class BaseResponseMessage
    {        
        public int StatusCode { get; set; }
       
        public string? Description { get; set; }
    }
}
