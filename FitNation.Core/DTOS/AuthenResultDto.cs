using System;
using System.Collections.Generic;
using System.Text;

namespace FitNation.Core.DTOS
{
    public class AuthenResultDto
    {

        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
