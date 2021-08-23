using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.InputModels
{
    public class FeedbackInputModel
    {
        public string Commentary { get; set; }
        public int ToUser { get; set; }
        public int FromUser { get; set; }
    }
}