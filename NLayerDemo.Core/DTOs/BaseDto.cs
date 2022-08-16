using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.Model
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreateUser { get; set; }
        public int UpdateUser { get; set; }
        public bool IsActive { get; set; }
    }
}
