﻿using System.ComponentModel.DataAnnotations;

namespace EventosApi.Common.Error
{
    public abstract class InnerError
    {
        public string Code { get; set; }

        [Required]
        public abstract string ErrorType { get; }
    }
}
