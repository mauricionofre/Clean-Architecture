using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.InputModels
{
    public class FeedbackInputModel
    {
        public string Commentary { get; set; }
        public long ToUser { get; set; }
        public long FromUser { get; set; }
    }
}